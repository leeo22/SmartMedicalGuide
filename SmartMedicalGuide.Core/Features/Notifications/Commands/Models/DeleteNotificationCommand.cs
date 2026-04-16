using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Notifications.Commands.Models
{
    public class DeleteNotificationCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteNotificationCommand(int id) => Id = id;
    }
}