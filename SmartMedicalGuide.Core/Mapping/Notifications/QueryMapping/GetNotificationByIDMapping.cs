using SmartMedicalGuide.Core.Features.Notifications.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Notifications
{
    public partial class NotificationProfile
    {
        public void GetSingleNotificationResponseMapping()
        {
            CreateMap<Notification, GetSingleNotificationResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.UserName : null))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User != null ? src.User.Email : null));
        }
    }
}