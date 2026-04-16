namespace SmartMedicalGuide.Core.Features.Prescriptions.Queries.Results
{
    public class GetSinglePrescriptionResponse
    {
        public int PrescriptionId { get; set; }
        public int DoctorAppointmentId { get; set; }
        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorEmail { get; set; }
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientEmail { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<PrescriptionItemDto>? Items { get; set; }
    }

    public class PrescriptionItemDto
    {
        public int ItemId { get; set; }
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public string Duration { get; set; }
    }
}