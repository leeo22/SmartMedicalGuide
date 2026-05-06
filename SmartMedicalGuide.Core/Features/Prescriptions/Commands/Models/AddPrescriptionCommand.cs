using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Commands.Models
{
    public class AddPrescriptionCommand : IRequest<Response<string>>
    {
        public int DoctorAppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public DateTime? FollowUpDate { get; set; }
    }
}