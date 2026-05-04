using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Queries.Models
{
    public class GetMedicalReportStatisticsQuery : IRequest<Response<object>>
    {
    }
}