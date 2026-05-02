using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.API.Hubs;
using SmartMedicalGuide.Data.AppMetaData;
using SmartMedicalGuide.Services.Abstracts;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [ApiController]
    [Authorize]
    public class ChatSignalRController : AppControllerBase
    {
        #region Fields
        private readonly IChatServices _chatServices;
        private readonly IMessageServices _messageServices;
        private readonly IChatParticipantServices _chatParticipantServices;
        private readonly IHubContext<ChatHub> _hubContext;
        #endregion

        #region Constructors
        public ChatSignalRController(
            IChatServices chatServices,
            IMessageServices messageServices,
            IChatParticipantServices chatParticipantServices,
            IHubContext<ChatHub> hubContext)
        {
            _chatServices = chatServices;
            _messageServices = messageServices;
            _chatParticipantServices = chatParticipantServices;
            _hubContext = hubContext;
        }
        #endregion

        #region Actions

        [SwaggerOperation(Summary = "إنشاء محادثة جديدة مع SignalR", OperationId = "CreateChatWithSignalR")]
        [HttpPost(Router.ChatSignalRRouting.CreateChat)]
        public async Task<IActionResult> CreateChat(int patientId, int doctorId)
        {
            var existingChat = await _chatServices.GetByPatientAndDoctorAsync(patientId, doctorId);
            if (existingChat != null)
                return Ok(new { success = true, chat = existingChat });

            var newChat = new Data.Entities.Chat
            {
                PatientId = patientId,
                DoctorId = doctorId,
                CreatedAt = DateTime.UtcNow,
                ChatName = $"Chat between Patient {patientId} and Doctor {doctorId}",
                IsActive = true,
                IsGroup = false
            };

            var result = await _chatServices.AddAsync(newChat);

            if (result == "Success")
            {
                await _chatParticipantServices.AddUserToChatAsync(newChat.ChatId, patientId, false);
                await _chatParticipantServices.AddUserToChatAsync(newChat.ChatId, doctorId, false);

                return Ok(new { success = true, chat = newChat });
            }

            return BadRequest(new { success = false, message = "Failed to create chat" });
        }

        [SwaggerOperation(Summary = "إرسال رسالة عبر SignalR", OperationId = "SendMessageViaSignalR")]
        [HttpPost(Router.ChatSignalRRouting.SendMessage)]
        public async Task<IActionResult> SendMessage(int chatId, string content, int? replyToMessageId = null)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out int userId))
                return Unauthorized();

            var chat = await _chatServices.GetByIDAsync(chatId);
            if (chat == null)
                return NotFound(new { success = false, message = "Chat not found" });

            var message = new Data.Entities.Message
            {
                ChatId = chatId,
                SenderId = userId,
                Content = content,
                SentAt = DateTime.UtcNow,
                IsRead = false,
                ReplyToMessageId = replyToMessageId
            };

            var result = await _messageServices.AddAsync(message);

            if (result == "Success")
            {
                chat.LastMessage = content;
                chat.LastMessageAt = DateTime.UtcNow;
                await _chatServices.EditAsync(chat);

                await _hubContext.Clients.Group($"chat_{chatId}").SendAsync("ReceiveMessage", new
                {
                    message.MessageId,
                    message.ChatId,
                    message.SenderId,
                    message.Content,
                    message.SentAt,
                    message.ReplyToMessageId
                });

                return Ok(new { success = true, message });
            }

            return BadRequest(new { success = false, message = "Failed to send message" });
        }

        #endregion
    }
}