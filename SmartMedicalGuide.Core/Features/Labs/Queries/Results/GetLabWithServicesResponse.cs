using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Features.Labs.Queries.Results
{
    public class GetLabWithServicesResponse
    {
        public int LabId { get; set; }
        public string LabName { get; set; }
        public string? CenterName { get; set; }
        public string? CenterType { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Location { get; set; }
        public string VerificationStatus { get; set; }
        public string? LabImageUrl { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? WorkingHours { get; set; }
        public List<LabServiceDto> Services { get; set; }
    }

    public class LabServiceDto
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}   