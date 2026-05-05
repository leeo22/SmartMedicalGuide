using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Clinics.Commands.Models
{
    public class EditClinicCommand : IRequest<Response<string>>
    {
        public int ClinicId { get; set; }
        public string? ClinicName { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Description { get; set; }
        public string? ClinicImageUrl { get; set; }
        public string? Email { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public TimeSpan? OpeningTime { get; set; }
        public TimeSpan? ClosingTime { get; set; }
        public bool IsActive { get; set; }
    }
}