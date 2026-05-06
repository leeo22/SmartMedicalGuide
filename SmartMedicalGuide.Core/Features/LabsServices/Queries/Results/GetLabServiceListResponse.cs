namespace SmartMedicalGuide.Core.Features.LabServices.Queries.Results
{
    public class GetLabServiceListResponse
    {
        public int ServiceId { get; set; }
        public int LabId { get; set; }
        public string LabName { get; set; }
        public string ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? FinalPrice { get; set; }
        public string? Category { get; set; }
        public int? Duration { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public bool IsActive { get; set; }
    }
}