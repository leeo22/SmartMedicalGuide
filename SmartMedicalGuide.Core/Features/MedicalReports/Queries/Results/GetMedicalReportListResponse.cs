namespace SmartMedicalGuide.Core.Features.MedicalReports.Queries.Results
{
    public class GetMedicalReportListResponse
    {
        public int ReportId { get; set; }
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public int LabId { get; set; }
        public string? LabName { get; set; }
        public string ReportType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}