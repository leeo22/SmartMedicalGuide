using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class ChatParticipantServices : IChatParticipantServices
    {
        #region Fields
        private readonly IChatParticipantRepository _chatParticipantRepository;
        #endregion

        #region Constructors
        public ChatParticipantServices(IChatParticipantRepository chatParticipantRepository)
        {
            _chatParticipantRepository = chatParticipantRepository;
        }
        #endregion

        #region Handlers Functions
        public async Task<string> AddAsync(ChatParticipant chatParticipant)
        {
            await _chatParticipantRepository.AddAsync(chatParticipant);
            return "Success";
        }

        public async Task<string> DeleteAsync(ChatParticipant chatParticipant)
        {
            var trans = _chatParticipantRepository.BeginTransaction();
            try
            {
                await _chatParticipantRepository.DeleteAsync(chatParticipant);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(ChatParticipant chatParticipant)
        {
            await _chatParticipantRepository.UpdateAsync(chatParticipant);
            return "Success";
        }

        public async Task<List<ChatParticipant>> GetByChatIdAsync(int chatId)
        {
            return await _chatParticipantRepository.GetByChatIdAsync(chatId);
        }

        public async Task<ChatParticipant> GetByIDAsync(int id)
        {
            var result = _chatParticipantRepository.GetByIdAsync()
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return result;
        }

        public async Task<List<ChatParticipant>> GetByUserIdAsync(int userId)
        {
            return await _chatParticipantRepository.GetByUserIdAsync(userId);
        }

        public async Task<List<ChatParticipant>> GetListAsync()
        {
            return await _chatParticipantRepository.GetTableAsTracking().ToListAsync();
        }

        public async Task<bool> IsUserInChatAsync(int chatId, int userId)
        {
            return await _chatParticipantRepository.IsUserInChatAsync(chatId, userId);
        }

        public async Task<ChatParticipant> GetParticipantAsync(int chatId, int userId)
        {
            return await _chatParticipantRepository.GetParticipantAsync(chatId, userId);
        }

        public async Task UpdateLastSeenAsync(int chatId, int userId, DateTime lastSeenAt)
        {
            await _chatParticipantRepository.UpdateLastSeenAsync(chatId, userId, lastSeenAt);
        }

        public async Task UpdateTypingStatusAsync(int chatId, int userId, bool isTyping)
        {
            await _chatParticipantRepository.UpdateTypingStatusAsync(chatId, userId, isTyping);
        }

        public async Task AddUserToChatAsync(int chatId, int userId, bool isAdmin = false)
        {
            var existing = await GetParticipantAsync(chatId, userId);
            if (existing == null)
            {
                var participant = new ChatParticipant
                {
                    ChatId = chatId,
                    UserId = userId,
                    JoinedAt = DateTime.UtcNow,
                    IsAdmin = isAdmin
                };
                await AddAsync(participant);
            }
        }

        public async Task RemoveUserFromChatAsync(int chatId, int userId)
        {
            var participant = await GetParticipantAsync(chatId, userId);
            if (participant != null)
            {
                await DeleteAsync(participant);
            }
        }
        #endregion
    }
}