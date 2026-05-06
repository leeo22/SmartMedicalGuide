namespace SmartMedicalGuide.Core.Features.Prescriptions.Queries.Results
{
    public class GetPrescriptionListResponse
    {
        public int PrescriptionId { get; set; }
        public int DoctorAppointmentId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public int ItemsCount { get; set; }
    }
}