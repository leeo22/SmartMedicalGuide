using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models
{
    public class EditLabAppointmentCommand : IRequest<Response<string>>
    {
        public int LabAppointmentId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? TestType { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public string? BookingSource { get; set; }
    }
}