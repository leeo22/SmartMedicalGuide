using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Labs.Commands.Models
{
    public class AddLabCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public string? CenterName { get; set; }
        public string? CenterType { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Location { get; set; }
        public string? LicenseNumber { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? LabImageUrl { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? WorkingHours { get; set; }
    }
}