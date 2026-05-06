namespace SmartMedicalGuide.Core.Features.Reviews.Queries.Results
{
    public class GetSingleReviewResponse
    {
        public int ReviewId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public string TargetType { get; set; }
        public int TargetId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsEdited { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}