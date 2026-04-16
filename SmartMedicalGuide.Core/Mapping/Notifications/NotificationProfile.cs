using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Notifications
{
    public partial class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            AddNotificationCommandMapping();
            EditNotificationCommandMapping();
            GetNotificationByIDMapping();
            GetNotificationListMapping();
        }
    }
}