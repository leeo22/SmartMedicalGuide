using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models
{
    public class CancelLabAppointmentCommand : IRequest<Response<string>>
    {
        public int AppointmentId { get; set; }
        public string? CancellationReason { get; set; }
        public int? RescheduledByUserId { get; set; }
    }
}