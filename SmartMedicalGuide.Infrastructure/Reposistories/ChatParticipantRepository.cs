using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class ChatParticipantRepository : GenericRepositoryAsync<ChatParticipant>, IChatParticipantRepository
    {
        #region Fields
        private readonly DbSet<ChatParticipant> _chatParticipant;
        #endregion

        #region Constructors
        public ChatParticipantRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _chatParticipant = dbContext.Set<ChatParticipant>(); ;
        }
        #endregion

        #region Handlers Functions
        public async Task<List<ChatParticipant>> GetByChatIdAsync(int chatId)
        {
            return await _dbContext.ChatParticipants
                .Include(cp => cp.User)
                .Where(cp => cp.ChatId == chatId)
                .ToListAsync();
        }

        public async Task<List<ChatParticipant>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.ChatParticipants
                .Include(cp => cp.Chat)
                .Where(cp => cp.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> IsUserInChatAsync(int chatId, int userId)
        {
            return await _dbContext.ChatParticipants
                .AnyAsync(cp => cp.ChatId == chatId && cp.UserId == userId);
        }

        public async Task<ChatParticipant> GetParticipantAsync(int chatId, int userId)
        {
            return await _dbContext.ChatParticipants
                .FirstOrDefaultAsync(cp => cp.ChatId == chatId && cp.UserId == userId);
        }

        public async Task UpdateLastSeenAsync(int chatId, int userId, DateTime lastSeenAt)
        {
            var participant = await GetParticipantAsync(chatId, userId);
            if (participant != null)
            {
                participant.LastSeenAt = lastSeenAt;
                await UpdateAsync(participant);
            }
        }

        public async Task UpdateTypingStatusAsync(int chatId, int userId, bool isTyping)
        {
            var participant = await GetParticipantAsync(chatId, userId);
            if (participant != null)
            {
                participant.IsTyping = isTyping;
                await UpdateAsync(participant);
            }
        }
        #endregion
    }
}