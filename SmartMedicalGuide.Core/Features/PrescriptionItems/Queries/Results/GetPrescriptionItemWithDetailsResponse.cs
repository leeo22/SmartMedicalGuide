namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Results
{
    public class GetPrescriptionItemWithDetailsResponse
    {
        public int ItemId { get; set; }
        public int PrescriptionId { get; set; }
        public string MedicineName { get; set; }
        public string? Dosage { get; set; }
        public string? Duration { get; set; }
        public string? Frequency { get; set; }
        public string? Instructions { get; set; }
        public int? Quantity { get; set; }
        public string? PrescriptionDescription { get; set; }
        public DateTime PrescriptionCreatedAt { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorEmail { get; set; }
        public string? PatientName { get; set; }
        public string? PatientEmail { get; set; }
    }
}