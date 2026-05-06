using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models
{
    public class AddLabAppointmentCommand : IRequest<Response<string>>
    {
        public int PatientId { get; set; }
        public int LabId { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? TestType { get; set; }
        public decimal? Price { get; set; }
        public string? BookingSource { get; set; }
        public string? Notes { get; set; }
    }
}