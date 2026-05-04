namespace SmartMedicalGuide.Core.Features.MedicalReports.Queries.Results
{
    public class GetMedicalReportListResponse
    {
        public int ReportId { get; set; }
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? ReportType { get; set; }
        public string? Description { get; set; }
        public DateTime ReportDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? FilePath { get; set; }
        public long? FileSize { get; set; }
        public string? ContentType { get; set; }
    }
}