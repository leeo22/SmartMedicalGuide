using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Models
{
    public class BulkAddPrescriptionItemsCommand : IRequest<Response<bool>>
    {
        public List<AddPrescriptionItemCommand> Items { get; set; }
    }
}