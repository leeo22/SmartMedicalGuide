using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Commands.Models
{
    public class AddPrescriptionCommand : IRequest<Response<string>>
    {
        public int DoctorAppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<AddPrescriptionItemDto>? Items { get; set; }
    }

    public class AddPrescriptionItemDto
    {
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Duration { get; set; }
    }
}