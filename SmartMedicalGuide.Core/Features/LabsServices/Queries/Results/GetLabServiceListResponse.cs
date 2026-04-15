namespace SmartMedicalGuide.Core.Features.LabsServices.Queries.Results
{
    public class GetLabServiceListResponse
    {
        public int ServiceId { get; set; }
        public int LabId { get; set; }
        public string? LabName { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}