using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Notifications.Commands.Models
{
    public class MarkAllAsReadCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
    }
}