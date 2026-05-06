using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Models
{
    public class UpdateItemQuantityCommand : IRequest<Response<bool>>
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}