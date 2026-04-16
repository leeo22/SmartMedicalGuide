using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

namespace SmartMedicalGuide.Services.Abstracts
{
    public class MessageServices : IMessageServices
    {
        #region Fields
        private readonly IMessageRepository _messageRepository;
        #endregion

        #region Constructors
        public MessageServices(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        #endregion

        #region Handlers Functions
        public async Task<string> AddAsync(Message message)
        {
            await _messageRepository.AddAsync(message);
            return "Success";
        }

        public async Task<string> DeleteAsync(Message message)
        {
            var trans = _messageRepository.BeginTransaction();
            try
            {
                await _messageRepository.DeleteAsync(message);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(Message message)
        {
            await _messageRepository.UpdateAsync(message);
            return "Success";
        }

        public async Task<List<Message>> GetByChatIdAsync(int chatId)
        {
            return await _messageRepository.GetTableAsTracking()
                .Where(x => x.ChatId == chatId)
                .OrderBy(x => x.SentAt)
                .ToListAsync();
        }

        public async Task<Message> GetByIDAsync(int id)
        {
            var result = _messageRepository.GetByIdAsync()
                                            .Where(x => x.MessageId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<List<Message>> GetBySenderIdAsync(int senderId)
        {
            return await _messageRepository.GetTableAsTracking()
                .Where(x => x.SenderId == senderId)
                .ToListAsync();
        }

        public async Task<List<Message>> GetListAsync()
        {
            return await _messageRepository.GetTableAsTracking().ToListAsync();
        }
        #endregion
    }
}