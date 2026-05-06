using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.LabServices.Queries.Results;

namespace SmartMedicalGuide.Core.Features.LabServices.Queries.Models
{
    public class GetLabServicesWithLabQuery : IRequest<Response<List<GetLabServiceListResponse>>>
    {
        public int LabId { get; set; }
    }
}