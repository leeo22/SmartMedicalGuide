using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.LabsServices.Queries.Results;

namespace SmartMedicalGuide.Core.Features.LabsServices.Queries.Models
{
    public class GetLabServiceListQuery : IRequest<Response<List<GetLabServiceListResponse>>>
    {
        public int? LabId { get; set; }

        public GetLabServiceListQuery() { }

        public GetLabServiceListQuery(int? labId)
        {
            LabId = labId;
        }
    }
}