using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

namespace SmartMedicalGuide.Services.Abstracts
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

        #region Handlers Functions
        public async Task<string> AddAsync(Notification notification)
        {
            await _notificationRepository.AddAsync(notification);
            return "Success";
        }

        public async Task<string> DeleteAsync(Notification notification)
        {
            var trans = _notificationRepository.BeginTransaction();
            try
            {
                await _notificationRepository.DeleteAsync(notification);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(Notification notification)
        {
            await _notificationRepository.UpdateAsync(notification);
            return "Success";
        }

        public async Task<Notification> GetByIDAsync(int id)
        {
            var result = _notificationRepository.GetByIdAsync()
                                            .Where(x => x.NotificationId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<List<Notification>> GetByUserIdAsync(int userId)
        {
            return await _notificationRepository.GetTableAsTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Notification>> GetListAsync()
        {
            return await _notificationRepository.GetTableAsTracking().ToListAsync();
        }

        public async Task<List<Notification>> GetUnreadByUserIdAsync(int userId)
        {
            return await _notificationRepository.GetTableAsTracking()
                .Where(x => x.UserId == userId && x.IsRead == false)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<int> GetUnreadCountByUserIdAsync(int userId)
        {
            return await _notificationRepository.GetTableAsTracking()
                .Where(x => x.UserId == userId && x.IsRead == false)
                .CountAsync();
        }
        #endregion
    }
}