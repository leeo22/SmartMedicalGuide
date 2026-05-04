using SmartMedicalGuide.Core.Features.Notifications.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Notifications
{
    public partial class NotificationProfile
    {
        public void GetNotificationListResponseMapping()
        {
            CreateMap<Notification, GetNotificationListResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.UserName : null));
        }
    }
}