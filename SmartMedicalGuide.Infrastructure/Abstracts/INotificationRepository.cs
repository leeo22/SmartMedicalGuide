using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface INotificationRepository : IGenericRepositoryAsync<Notification>
    {
        Task<Notification?> GetNotificationByIdWithIncludesAsync(int id);
        Task<List<Notification>> GetAllNotificationsWithIncludesAsync();
        Task<List<Notification>> GetByUserIdAsync(int userId);
        Task<List<Notification>> GetUnreadByUserIdAsync(int userId);
        Task<List<Notification>> GetReadByUserIdAsync(int userId);
        Task<List<Notification>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);
        Task<List<Notification>> GetByTypeAsync(string notificationType);
        Task<int> GetUnreadCountAsync(int userId);
        Task<bool> MarkAsReadAsync(int notificationId);
        Task<bool> MarkAllAsReadAsync(int userId);
        Task<bool> DeleteAllByUserIdAsync(int userId);
        Task<object> GetNotificationStatisticsAsync();
        Task<bool> SendBulkNotificationAsync(List<Notification> notifications);
    }
}