using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface INotificationServices
    {
        public Task<List<Notification>> GetListAsync();
        public Task<Notification> GetByIDAsync(int id);
        public Task<string> AddAsync(Notification notification);
        public Task<string> EditAsync(Notification notification);
        public Task<string> DeleteAsync(Notification notification);
        public Task<List<Notification>> GetByUserIdAsync(int userId);
        public Task<List<Notification>> GetUnreadByUserIdAsync(int userId);
        public Task<int> GetUnreadCountByUserIdAsync(int userId);
    }
}