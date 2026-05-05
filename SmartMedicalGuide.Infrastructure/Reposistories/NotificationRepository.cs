using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class NotificationRepository : GenericRepositoryAsync<Notification>, INotificationRepository
    {
        #region Fields
        private readonly DbSet<Notification> _notifications;
        #endregion

        #region Constructors
        public NotificationRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _notifications = dbContext.Set<Notification>();
        }
        #endregion

        #region Basic Handlers
        public async Task<Notification?> GetNotificationByIdWithIncludesAsync(int id)
        {
            return await _notifications
                .Include(x => x.User)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.NotificationId == id);
        }

        public async Task<List<Notification>> GetAllNotificationsWithIncludesAsync()
        {
            return await _notifications
                .Include(x => x.User)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<List<Notification>> GetByUserIdAsync(int userId)
        {
            return await _notifications
                .Include(x => x.User)
                .Where(x => x.UserId == userId && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Notification>> GetUnreadByUserIdAsync(int userId)
        {
            return await _notifications
                .Include(x => x.User)
                .Where(x => x.UserId == userId && !x.IsRead && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Notification>> GetReadByUserIdAsync(int userId)
        {
            return await _notifications
                .Include(x => x.User)
                .Where(x => x.UserId == userId && x.IsRead && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Notification>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            return await _notifications
                .Include(x => x.User)
                .Where(x => x.CreatedAt >= fromDate && x.CreatedAt <= toDate && !x.IsDeleted)
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Notification>> GetByTypeAsync(string notificationType)
        {
            return await _notifications
                .Include(x => x.User)
                .Where(x => x.NotificationType == notificationType && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<int> GetUnreadCountAsync(int userId)
        {
            return await _notifications
                .CountAsync(x => x.UserId == userId && !x.IsRead && !x.IsDeleted);
        }

        public async Task<bool> MarkAsReadAsync(int notificationId)
        {
            try
            {
                var notification = await _notifications
                    .FirstOrDefaultAsync(x => x.NotificationId == notificationId && !x.IsDeleted);

                if (notification == null)
                    return false;

                notification.IsRead = true;
                await UpdateAsync(notification);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> MarkAllAsReadAsync(int userId)
        {
            try
            {
                var notifications = await _notifications
                    .Where(x => x.UserId == userId && !x.IsRead && !x.IsDeleted)
                    .ToListAsync();

                foreach (var notification in notifications)
                {
                    notification.IsRead = true;
                }

                _notifications.UpdateRange(notifications);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAllByUserIdAsync(int userId)
        {
            try
            {
                var notifications = await _notifications
                    .Where(x => x.UserId == userId && !x.IsDeleted)
                    .ToListAsync();

                foreach (var notification in notifications)
                {
                    notification.IsDeleted = true;
                }

                _notifications.UpdateRange(notifications);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<object> GetNotificationStatisticsAsync()
        {
            var notifications = await _notifications.Where(x => !x.IsDeleted).ToListAsync();

            return new
            {
                TotalNotifications = notifications.Count,
                ReadCount = notifications.Count(x => x.IsRead),
                UnreadCount = notifications.Count(x => !x.IsRead),
                ByType = notifications.GroupBy(x => x.NotificationType)
                    .Select(g => new { Type = g.Key, Count = g.Count() }),
                ByDay = notifications.GroupBy(x => x.CreatedAt.Date)
                    .Select(g => new { Date = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Date)
                    .Take(30)
            };
        }

        public async Task<bool> SendBulkNotificationAsync(List<Notification> notifications)
        {
            try
            {
                foreach (var notification in notifications)
                {
                    notification.CreatedAt = DateTime.UtcNow;
                    notification.IsRead = false;
                    notification.IsDeleted = false;
                }

                await _notifications.AddRangeAsync(notifications);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}