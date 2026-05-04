using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models
{
    public class CancelAppointmentCommand : IRequest<Response<string>>
    {
        public int AppointmentId { get; set; }
        public string? CancellationReason { get; set; }
        public int? RescheduledByUserId { get; set; }
    }
}