namespace SmartMedicalGuide.Core.Features.Reviews.Queries.Results
{
    public class GetReviewListResponse
    {
        public int ReviewId { get; set; }
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public string TargetType { get; set; }
        public int TargetId { get; set; }
        public string? TargetName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}