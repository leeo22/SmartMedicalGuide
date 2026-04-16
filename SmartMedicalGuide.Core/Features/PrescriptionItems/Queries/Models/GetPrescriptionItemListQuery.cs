using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Results;

namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Models
{
    public class GetPrescriptionItemListQuery : IRequest<Response<List<GetPrescriptionItemListResponse>>>
    {
        public int? PrescriptionId { get; set; }
        public GetPrescriptionItemListQuery() { }
        public GetPrescriptionItemListQuery(int? prescriptionId) => PrescriptionId = prescriptionId;
    }
}