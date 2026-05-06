using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models
{
    public class CompleteLabAppointmentCommand : IRequest<Response<string>>
    {
        public int AppointmentId { get; set; }
    }
}