using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models
{
    public class EditDoctorAppointmentCommand : IRequest<Response<string>>
    {
        public int AppointmentId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }
        public string? AppointmentType { get; set; }
        public string? FullName { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsPostponed { get; set; }
        public DateTime? NewAppointmentDate { get; set; }
        public DateTime? OriginalAppointmentDate { get; set; }
        public string? PostponeReason { get; set; }
        public string? CancellationReason { get; set; }
    }
}