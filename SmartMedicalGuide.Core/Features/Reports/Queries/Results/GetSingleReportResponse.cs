namespace SmartMedicalGuide.Core.Features.Reports.Queries.Results
{
    public class GetSingleReportResponse
    {
        public int ReportId { get; set; }

        public int ReporterUserId { get; set; }

        public string? TargetType { get; set; }
        public int TargetId { get; set; }

        public string? Reason { get; set; }
        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
