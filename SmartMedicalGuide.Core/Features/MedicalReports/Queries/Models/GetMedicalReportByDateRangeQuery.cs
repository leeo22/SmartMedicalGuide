using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.MedicalReports.Queries.Results;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Queries.Models
{
    public class GetMedicalReportByDateRangeQuery : IRequest<Response<List<GetMedicalReportListResponse>>>
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}