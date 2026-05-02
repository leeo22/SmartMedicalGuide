using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IChatParticipantServices
    {
        Task<List<ChatParticipant>> GetListAsync();
        Task<ChatParticipant> GetByIDAsync(int id);
        Task<string> AddAsync(ChatParticipant chatParticipant);
        Task<string> EditAsync(ChatParticipant chatParticipant);
        Task<string> DeleteAsync(ChatParticipant chatParticipant);
        Task<List<ChatParticipant>> GetByChatIdAsync(int chatId);
        Task<List<ChatParticipant>> GetByUserIdAsync(int userId);
        Task<bool> IsUserInChatAsync(int chatId, int userId);
        Task<ChatParticipant> GetParticipantAsync(int chatId, int userId);
        Task UpdateLastSeenAsync(int chatId, int userId, DateTime lastSeenAt);
        Task UpdateTypingStatusAsync(int chatId, int userId, bool isTyping);
        Task AddUserToChatAsync(int chatId, int userId, bool isAdmin = false);
        Task RemoveUserFromChatAsync(int chatId, int userId);
    }
}