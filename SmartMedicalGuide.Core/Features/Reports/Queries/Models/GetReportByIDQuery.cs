using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Reports.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Reports.Queries.Models
{
    public class GetReportByIDQuery : IRequest<Response<GetSingleReportResponse>>
    {
        public int Id { get; set; }
        public GetReportByIDQuery(int id)
        {
            Id = id;
        }
    }
}
