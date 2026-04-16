using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface INotificationRepository : IGenericRepositoryAsync<Notification>
    {
        //public Task<List<Notification>> GetNotificationsListAsync();
    }
}
