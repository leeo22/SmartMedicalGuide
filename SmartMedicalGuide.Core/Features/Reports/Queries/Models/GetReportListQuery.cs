using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Reports.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Reports.Queries.Models
{
    public class GetReportListQuery : IRequest<Response<List<GetReportListResponse>>>
    {
    }
}
