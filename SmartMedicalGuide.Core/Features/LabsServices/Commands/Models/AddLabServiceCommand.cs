using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.LabsServices.Commands.Models
{
    public class AddLabServiceCommand : IRequest<Response<string>>
    {
        public int LabId { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}