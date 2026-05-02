using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;
using System.Security.Claims;

namespace SmartMedicalGuide.API.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        #region Fields
        private readonly IChatServices _chatServices;
        private readonly IMessageServices _messageServices;
        private readonly IChatParticipantServices _chatParticipantServices;
        private static readonly Dictionary<string, int> _connectedUsers = new(); // ConnectionId -> UserId
        #endregion

        #region Constructors
        public ChatHub(
            IChatServices chatServices,
            IMessageServices messageServices,
            IChatParticipantServices chatParticipantServices)
        {
            _chatServices = chatServices;
            _messageServices = messageServices;
            _chatParticipantServices = chatParticipantServices;
        }
        #endregion

        #region Connection Handlers
        public override async Task OnConnectedAsync()
        {
            var userId = GetCurrentUserId();
            if (userId.HasValue)
            {
                _connectedUsers[Context.ConnectionId] = userId.Value;

                // تحديث LastSeen للمستخدم في جميع المحادثات
                await UpdateUserLastSeenInAllChats(userId.Value);

                // انضم إلى المحادثات التي يشارك فيها المستخدم
                var userChats = await GetUserChatsAsync(userId.Value);
                foreach (var chat in userChats)
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, $"chat_{chat.ChatId}");

                    // إعلام الآخرين بأن المستخدم أصبح متصلاً
                    await Clients.OthersInGroup($"chat_{chat.ChatId}").SendAsync("UserOnline", userId.Value);
                }
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = GetCurrentUserId();
            if (userId.HasValue)
            {
                _connectedUsers.Remove(Context.ConnectionId);

                // إعلام الآخرين بأن المستخدم أصبح غير متصل
                var userChats = await GetUserChatsAsync(userId.Value);
                foreach (var chat in userChats)
                {
                    await Clients.OthersInGroup($"chat_{chat.ChatId}").SendAsync("UserOffline", userId.Value);
                }
            }

            await base.OnDisconnectedAsync(exception);
        }
        #endregion

        #region Chat Methods

        /// <summary>
        /// إرسال رسالة جديدة
        /// </summary>
        public async Task SendMessage(int chatId, string content, int? replyToMessageId = null)
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue) return;

            // التحقق من وجود المحادثة
            var chat = await _chatServices.GetByIDAsync(chatId);
            if (chat == null) return;

            // التحقق من أن المستخدم مشارك في المحادثة
            if (!await IsUserInChatAsync(chatId, userId.Value)) return;

            // إنشاء الرسالة
            var message = new Message
            {
                ChatId = chatId,
                SenderId = userId.Value,
                Content = content,
                SentAt = DateTime.UtcNow,
                IsRead = false,
                ReplyToMessageId = replyToMessageId
            };

            var result = await _messageServices.AddAsync(message);

            if (result == "Success")
            {
                // تحديث آخر رسالة في المحادثة
                chat.LastMessage = content;
                chat.LastMessageAt = DateTime.UtcNow;
                await _chatServices.EditAsync(chat);

                // جلب اسم المرسل
                var senderName = await GetUserNameAsync(userId.Value);

                // إرسال الرسالة لجميع المشاركين في المحادثة
                await Clients.Group($"chat_{chatId}").SendAsync("ReceiveMessage", new
                {
                    message.MessageId,
                    message.ChatId,
                    message.SenderId,
                    message.Content,
                    message.SentAt,
                    message.ReplyToMessageId,
                    SenderName = senderName
                });
            }
        }

        /// <summary>
        /// بدء الكتابة
        /// </summary>
        public async Task StartTyping(int chatId)
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue) return;

            await _chatParticipantServices.UpdateTypingStatusAsync(chatId, userId.Value, true);
            await Clients.OthersInGroup($"chat_{chatId}").SendAsync("UserTyping", chatId, userId.Value);
        }

        /// <summary>
        /// إيقاف الكتابة
        /// </summary>
        public async Task StopTyping(int chatId)
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue) return;

            await _chatParticipantServices.UpdateTypingStatusAsync(chatId, userId.Value, false);
            await Clients.OthersInGroup($"chat_{chatId}").SendAsync("UserStoppedTyping", chatId, userId.Value);
        }

        /// <summary>
        /// تحديد قراءة جميع الرسائل في محادثة
        /// </summary>
        public async Task MarkChatAsRead(int chatId)
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue) return;

            var messages = await _messageServices.GetByChatIdAsync(chatId);
            var unreadMessages = messages.Where(m => m.SenderId != userId.Value && !m.IsRead);

            foreach (var message in unreadMessages)
            {
                message.IsRead = true;
                message.ReadAt = DateTime.UtcNow;
                await _messageServices.EditAsync(message);
            }

            // تحديث LastSeen
            await _chatParticipantServices.UpdateLastSeenAsync(chatId, userId.Value, DateTime.UtcNow);

            await Clients.Group($"chat_{chatId}").SendAsync("ChatRead", chatId, userId.Value);
        }

        /// <summary>
        /// حذف رسالة
        /// </summary>
        public async Task DeleteMessage(int messageId)
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue) return;

            var message = await _messageServices.GetByIDAsync(messageId);
            if (message != null && message.SenderId == userId.Value)
            {
                message.IsDeleted = true;
                await _messageServices.EditAsync(message);
                await Clients.Group($"chat_{message.ChatId}").SendAsync("MessageDeleted", messageId);
            }
        }

        /// <summary>
        /// جلب رسائل محادثة (للتحميل عند الطلب)
        /// </summary>
        public async Task GetChatMessages(int chatId, int page = 1, int pageSize = 50)
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue) return;

            if (!await IsUserInChatAsync(chatId, userId.Value)) return;

            var messages = await _messageServices.GetByChatIdAsync(chatId);
            var pagedMessages = messages
                .OrderByDescending(m => m.SentAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(m => m.SentAt)
                .ToList();

            await Clients.Caller.SendAsync("ChatMessages", new
            {
                ChatId = chatId,
                Page = page,
                PageSize = pageSize,
                TotalCount = messages.Count,
                Messages = pagedMessages.Select(m => new
                {
                    m.MessageId,
                    m.ChatId,
                    m.SenderId,
                    m.Content,
                    m.SentAt,
                    m.IsRead,
                    m.ReplyToMessageId
                })
            });
        }

        /// <summary>
        /// إضافة مشارك جديد للمحادثة (للمحادثات الجماعية)
        /// </summary>
        public async Task AddParticipantToChat(int chatId, int newUserId, bool isAdmin = false)
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue) return;

            // التحقق من أن المستخدم الحالي مشارك في المحادثة
            if (!await IsUserInChatAsync(chatId, userId.Value)) return;

            // إضافة المشارك الجديد
            await _chatParticipantServices.AddUserToChatAsync(chatId, newUserId, isAdmin);

            // إضافة المشارك الجديد إلى مجموعة SignalR
            var connectionIds = _connectedUsers
                .Where(u => u.Value == newUserId)
                .Select(u => u.Key)
                .ToList();

            foreach (var connectionId in connectionIds)
            {
                await Groups.AddToGroupAsync(connectionId, $"chat_{chatId}");
            }

            // إعلام الجميع بالمشارك الجديد
            await Clients.Group($"chat_{chatId}").SendAsync("ParticipantAdded", new
            {
                ChatId = chatId,
                UserId = newUserId,
                IsAdmin = isAdmin
            });
        }

        /// <summary>
        /// إزالة مشارك من المحادثة
        /// </summary>
        public async Task RemoveParticipantFromChat(int chatId, int userIdToRemove)
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue) return;

            // التحقق من أن المستخدم الحالي مشارك في المحادثة
            if (!await IsUserInChatAsync(chatId, userId.Value)) return;

            // إزالة المشارك
            await _chatParticipantServices.RemoveUserFromChatAsync(chatId, userIdToRemove);

            // إزالة المشارك من مجموعة SignalR
            var connectionIds = _connectedUsers
                .Where(u => u.Value == userIdToRemove)
                .Select(u => u.Key)
                .ToList();

            foreach (var connectionId in connectionIds)
            {
                await Groups.RemoveFromGroupAsync(connectionId, $"chat_{chatId}");
            }

            // إعلام الجميع بالمشارك تمت إزالته
            await Clients.Group($"chat_{chatId}").SendAsync("ParticipantRemoved", new
            {
                ChatId = chatId,
                UserId = userIdToRemove
            });
        }

        #endregion

        #region Private Helpers

        private int? GetCurrentUserId()
        {
            var userIdClaim = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userIdClaim, out int userId))
                return userId;
            return null;
        }

        private async Task<List<Chat>> GetUserChatsAsync(int userId)
        {
            var userParticipants = await _chatParticipantServices.GetByUserIdAsync(userId);
            var chatIds = userParticipants.Select(cp => cp.ChatId).Distinct().ToList();

            var chats = new List<Chat>();
            foreach (var chatId in chatIds)
            {
                var chat = await _chatServices.GetByIDAsync(chatId);
                if (chat != null)
                    chats.Add(chat);
            }

            return chats;
        }

        private async Task<bool> IsUserInChatAsync(int chatId, int userId)
        {
            return await _chatParticipantServices.IsUserInChatAsync(chatId, userId);
        }

        private async Task UpdateUserLastSeenInAllChats(int userId)
        {
            var userChats = await GetUserChatsAsync(userId);
            foreach (var chat in userChats)
            {
                await _chatParticipantServices.UpdateLastSeenAsync(chat.ChatId, userId, DateTime.UtcNow);
            }
        }

        private async Task<string> GetUserNameAsync(int userId)
        {
            // إذا كان لديك UserManager يمكنك استخدامه
            // مؤقتاً نرجع المعرف
            // يمكنك حقن UserManager<User> لتحسين هذا
            return userId.ToString();
        }

        /// <summary>
        /// جلب جميع المستخدمين المتصلين حالياً في محادثة
        /// </summary>
        public async Task GetOnlineUsersInChat(int chatId)
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue) return;

            if (!await IsUserInChatAsync(chatId, userId.Value)) return;

            var participantUserIds = await GetChatParticipantUserIdsAsync(chatId);
            var onlineUserIds = _connectedUsers.Values.Distinct().ToList();
            var onlineParticipants = participantUserIds.Intersect(onlineUserIds).ToList();

            await Clients.Caller.SendAsync("OnlineUsers", new
            {
                ChatId = chatId,
                OnlineUserIds = onlineParticipants
            });
        }

        private async Task<List<int>> GetChatParticipantUserIdsAsync(int chatId)
        {
            var participants = await _chatParticipantServices.GetByChatIdAsync(chatId);
            return participants.Select(p => p.UserId).ToList();
        }

        #endregion
    }
}