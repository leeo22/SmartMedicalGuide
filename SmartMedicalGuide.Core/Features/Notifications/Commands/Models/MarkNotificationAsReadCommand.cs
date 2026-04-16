using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Notifications.Commands.Models
{
    public class MarkNotificationAsReadCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public MarkNotificationAsReadCommand(int id) => Id = id;
    }
}