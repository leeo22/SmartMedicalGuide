namespace SmartMedicalGuide.Core.Features.Prescriptions.Queries.Results
{
    public class GetSinglePrescriptionResponse
    {
        public int PrescriptionId { get; set; }
        public int DoctorAppointmentId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorEmail { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string Status { get; set; }
    }
}