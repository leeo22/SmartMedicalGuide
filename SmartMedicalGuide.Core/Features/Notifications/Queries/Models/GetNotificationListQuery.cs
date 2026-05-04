using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Notifications.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Notifications.Queries.Models
{
    public class GetNotificationListQuery : IRequest<Response<List<GetNotificationListResponse>>>
    {
        public int? UserId { get; set; }
        public bool? IsRead { get; set; }
        public string? NotificationType { get; set; }
    }
}