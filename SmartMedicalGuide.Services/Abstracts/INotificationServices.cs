using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface INotificationServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<Notification>> GetListAsync();
        Task<Notification?> GetByIDAsync(int id);
        Task<string> AddAsync(Notification notification);
        Task<string> EditAsync(Notification notification);
        Task<string> DeleteAsync(Notification notification);
        #endregion

        #region Additional Important Functions - 5 Functions
        Task<List<Notification>> GetByUserIdAsync(int userId);
        Task<List<Notification>> GetUnreadByUserIdAsync(int userId);
        Task<int> GetUnreadCountAsync(int userId);
        Task<bool> MarkAsReadAsync(int notificationId);
        Task<bool> MarkAllAsReadAsync(int userId);
        #endregion
    }
}