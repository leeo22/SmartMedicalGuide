using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models
{
    public class DeleteLabAppointmentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteLabAppointmentCommand(int id) => Id = id;
    }
}