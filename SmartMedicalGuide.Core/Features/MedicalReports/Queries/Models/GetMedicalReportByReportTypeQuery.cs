using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.MedicalReports.Queries.Results;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Queries.Models
{
    public class GetMedicalReportByReportTypeQuery : IRequest<Response<List<GetMedicalReportListResponse>>>
    {
        public string ReportType { get; set; }
    }
}