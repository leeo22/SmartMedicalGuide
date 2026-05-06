using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Models
{
    public class EditPrescriptionItemCommand : IRequest<Response<string>>
    {
        public int ItemId { get; set; }
        public string? MedicineName { get; set; }
        public string? Dosage { get; set; }
        public string? Duration { get; set; }
        public string? Frequency { get; set; }
        public string? Instructions { get; set; }
        public int? Quantity { get; set; }
    }
}