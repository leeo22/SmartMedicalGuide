using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Queries.Results
{
    public class GetPrescriptionWithItemsResponse
    {
        public int PrescriptionId { get; set; }
        public int DoctorAppointmentId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string Status { get; set; }
        public List<PrescriptionItemDto> PrescriptionItems { get; set; }
    }

    public class PrescriptionItemDto
    {
        public int ItemId { get; set; }
        public string MedicineName { get; set; }
        public string? Dosage { get; set; }
        public string? Duration { get; set; }
        public string? Frequency { get; set; }
        public string? Instructions { get; set; }
        public int? Quantity { get; set; }
    }
}