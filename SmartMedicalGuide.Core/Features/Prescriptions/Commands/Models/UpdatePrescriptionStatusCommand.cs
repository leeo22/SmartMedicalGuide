using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Commands.Models
{
    public class UpdatePrescriptionStatusCommand : IRequest<Response<string>>
    {
        public int PrescriptionId { get; set; }
        public string Status { get; set; }
    }
}