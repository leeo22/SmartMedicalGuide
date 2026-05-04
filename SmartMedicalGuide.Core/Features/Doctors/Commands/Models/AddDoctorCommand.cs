using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Doctors.Commands.Models
{
    public class AddDoctorCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public int? SpecializationId { get; set; }
        public string? Bio { get; set; }
        public string? LicenseNumber { get; set; }
        public decimal? ConsultationPrice { get; set; }
        public string? AvailableTimes { get; set; }
        public int? YearsOfExperience { get; set; }
        public string? Gender { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}