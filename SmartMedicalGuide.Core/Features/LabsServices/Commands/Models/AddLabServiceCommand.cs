using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.LabServices.Commands.Models
{
    public class AddLabServiceCommand : IRequest<Response<string>>
    {
        public int LabId { get; set; }
        public string ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public int? Duration { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? DiscountPercentage { get; set; }
    }
}