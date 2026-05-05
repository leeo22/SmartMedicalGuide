using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Notifications.Commands.Models
{
    public class EditNotificationCommand : IRequest<Response<string>>
    {
        public int NotificationId { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public string? NotificationType { get; set; }
        public int? RelatedEntityId { get; set; }
        public string? RelatedEntityType { get; set; }
        public string? ImageUrl { get; set; }
        public string? ActionUrl { get; set; }
    }
}