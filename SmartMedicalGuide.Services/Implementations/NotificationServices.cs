using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class NotificationServices : INotificationServices
    {
        #region Fields
        private readonly INotificationRepository _notificationRepository;
        #endregion

        #region Constructors
        public NotificationServices(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<Notification>> GetListAsync()
        {
            try
            {
                return await _notificationRepository.GetAllNotificationsWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting notifications list: {ex.Message}", ex);
            }
        }

        public async Task<Notification?> GetByIDAsync(int id)
        {
            try
            {
                return await _notificationRepository.GetNotificationByIdWithIncludesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting notification by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(Notification notification)
        {
            try
            {
                notification.CreatedAt = DateTime.UtcNow;
                notification.IsRead = false;
                notification.IsDeleted = false;

                await _notificationRepository.AddAsync(notification);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add notification: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(Notification notification)
        {
            try
            {
                var existing = await _notificationRepository.GetTableAsTracking()
                    .FirstOrDefaultAsync(x => x.NotificationId == notification.NotificationId && !x.IsDeleted);

                if (existing == null)
                    return "Notification not found";

                existing.Title = notification.Title ?? existing.Title;
                existing.Message = notification.Message ?? existing.Message;
                existing.NotificationType = notification.NotificationType ?? existing.NotificationType;
                existing.RelatedEntityId = notification.RelatedEntityId ?? existing.RelatedEntityId;
                existing.RelatedEntityType = notification.RelatedEntityType ?? existing.RelatedEntityType;
                existing.ImageUrl = notification.ImageUrl ?? existing.ImageUrl;
                existing.ActionUrl = notification.ActionUrl ?? existing.ActionUrl;

                await _notificationRepository.UpdateAsync(existing);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit notification: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(Notification notification)
        {
            try
            {
                notification.IsDeleted = true;
                await _notificationRepository.UpdateAsync(notification);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete notification: {ex.Message}";
            }
        }
        #endregion

        #region Additional Important Functions
        public async Task<List<Notification>> GetByUserIdAsync(int userId)
        {
            try
            {
                return await _notificationRepository.GetByUserIdAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting notifications for user {userId}: {ex.Message}", ex);
            }
        }

        public async Task<List<Notification>> GetUnreadByUserIdAsync(int userId)
        {
            try
            {
                return await _notificationRepository.GetUnreadByUserIdAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting unread notifications for user {userId}: {ex.Message}", ex);
            }
        }

        public async Task<int> GetUnreadCountAsync(int userId)
        {
            try
            {
                return await _notificationRepository.GetUnreadCountAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting unread count for user {userId}: {ex.Message}", ex);
            }
        }

        public async Task<bool> MarkAsReadAsync(int notificationId)
        {
            try
            {
                return await _notificationRepository.MarkAsReadAsync(notificationId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error marking notification {notificationId} as read: {ex.Message}", ex);
            }
        }

        public async Task<bool> MarkAllAsReadAsync(int userId)
        {
            try
            {
                return await _notificationRepository.MarkAllAsReadAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error marking all notifications as read for user {userId}: {ex.Message}", ex);
            }
        }
        #endregion
    }
}