using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Results;

namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Models
{
    public class GetPrescriptionItemsWithDetailsQuery : IRequest<Response<List<GetPrescriptionItemWithDetailsResponse>>>
    {
        public int PrescriptionId { get; set; }
    }
}