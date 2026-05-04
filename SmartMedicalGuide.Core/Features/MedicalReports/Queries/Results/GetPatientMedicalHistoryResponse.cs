namespace SmartMedicalGuide.Core.Features.MedicalReports.Queries.Results
{
    public class GetPatientMedicalHistoryResponse
    {
        public int ReportId { get; set; }
        public string? ReportType { get; set; }
        public string? Description { get; set; }
        public DateTime ReportDate { get; set; }
        public string? DoctorName { get; set; }
        public string? FilePath { get; set; }
    }
}