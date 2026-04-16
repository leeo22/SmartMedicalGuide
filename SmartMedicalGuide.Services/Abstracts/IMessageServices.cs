using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IMessageServices
    {
        public Task<List<Message>> GetListAsync();
        public Task<Message> GetByIDAsync(int id);
        public Task<string> AddAsync(Message message);
        public Task<string> EditAsync(Message message);
        public Task<string> DeleteAsync(Message message);
        public Task<List<Message>> GetByChatIdAsync(int chatId);
        public Task<List<Message>> GetBySenderIdAsync(int senderId);
    }
}