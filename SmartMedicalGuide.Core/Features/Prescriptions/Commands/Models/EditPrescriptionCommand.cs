using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Commands.Models
{
    public class EditPrescriptionCommand : IRequest<Response<string>>
    {
        public int PrescriptionId { get; set; }
        public int DoctorAppointmentId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<EditPrescriptionItemDto>? Items { get; set; }
    }

    public class EditPrescriptionItemDto
    {
        public int ItemId { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Duration { get; set; }
    }
}