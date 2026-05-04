using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models
{
    public class CompleteAppointmentCommand : IRequest<Response<string>>
    {
        public int AppointmentId { get; set; }
    }
}