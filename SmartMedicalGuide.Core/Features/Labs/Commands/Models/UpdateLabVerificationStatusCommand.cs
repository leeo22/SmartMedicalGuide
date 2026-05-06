using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Labs.Commands.Models
{
    public class UpdateLabVerificationStatusCommand : IRequest<Response<string>>
    {
        public int LabId { get; set; }
        public string VerificationStatus { get; set; }
    }
}