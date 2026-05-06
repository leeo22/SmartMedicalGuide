using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Results;

namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Models
{
    public class GetPrescriptionItemByIdQuery : IRequest<Response<GetSinglePrescriptionItemResponse>>
    {
        public int Id { get; set; }
        public GetPrescriptionItemByIdQuery(int id) => Id = id;
    }
}