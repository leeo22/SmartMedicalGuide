using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Models
{
    public class AddPrescriptionItemCommand : IRequest<Response<string>>
    {
        public int PrescriptionId { get; set; }
        public string MedicineName { get; set; }
        public string? Dosage { get; set; }
        public string? Duration { get; set; }
        public string? Frequency { get; set; }
        public string? Instructions { get; set; }
        public int? Quantity { get; set; }
    }
}