namespace SmartMedicalGuide.Core.Features.Labs.Queries.Results
{
    public class GetLabListResponse
    {
        public int LabId { get; set; }
        public int UserId { get; set; }
        public string LabName { get; set; }
        public string? CenterName { get; set; }
        public string? CenterType { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Location { get; set; }
        public string VerificationStatus { get; set; }
        public string? LabImageUrl { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? WorkingHours { get; set; }
        public int ServicesCount { get; set; }
    }
}