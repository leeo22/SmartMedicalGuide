using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IChatParticipantRepository : IGenericRepositoryAsync<ChatParticipant>
    {
        // Get participants by chat ID
        Task<List<ChatParticipant>> GetByChatIdAsync(int chatId);

        // Get participants by user ID
        Task<List<ChatParticipant>> GetByUserIdAsync(int userId);

        // Check if user is participant in chat
        Task<bool> IsUserInChatAsync(int chatId, int userId);

        // Get single participant by chat and user
        Task<ChatParticipant> GetParticipantAsync(int chatId, int userId);

        // Update last seen
        Task UpdateLastSeenAsync(int chatId, int userId, DateTime lastSeenAt);

        // Update typing status
        Task UpdateTypingStatusAsync(int chatId, int userId, bool isTyping);
    }
}