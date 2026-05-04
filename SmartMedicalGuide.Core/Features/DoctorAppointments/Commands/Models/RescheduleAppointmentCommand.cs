using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models
{
    public class RescheduleAppointmentCommand : IRequest<Response<string>>
    {
        public int AppointmentId { get; set; }
        public DateTime NewAppointmentDate { get; set; }
        public string? Reason { get; set; }
        public int? RescheduledByUserId { get; set; }
    }
}