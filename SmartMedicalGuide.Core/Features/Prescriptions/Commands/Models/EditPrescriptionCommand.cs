using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Commands.Models
{
    public class EditPrescriptionCommand : IRequest<Response<string>>
    {
        public int PrescriptionId { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public string? Status { get; set; }
    }
}