using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Notifications.Commands.Models
{
    public class MarkAsReadCommand : IRequest<Response<string>>
    {
        public int NotificationId { get; set; }
    }
}