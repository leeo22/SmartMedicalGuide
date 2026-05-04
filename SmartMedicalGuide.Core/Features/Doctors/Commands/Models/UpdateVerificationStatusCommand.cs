using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Doctors.Commands.Models
{
    public class UpdateVerificationStatusCommand : IRequest<Response<string>>
    {
        public int DoctorId { get; set; }
        public string VerificationStatus { get; set; }
    }
}