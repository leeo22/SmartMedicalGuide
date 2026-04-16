using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class NotificationRepository : GenericRepositoryAsync<Notification>, INotificationRepository
    {
        #region Fields
        private readonly DbSet<Notification> _notification;
        #endregion

        #region Constructors
        public NotificationRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _notification = dBContext.Set<Notification>();

        }

        #endregion

        #region Handels Functions

        #endregion

    }
}
