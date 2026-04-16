using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.MedicalReports.Queries.Results;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Queries.Models
{
    public class GetMedicalReportByIDQuery : IRequest<Response<GetSingleMedicalReportResponse>>
    {
        public int Id { get; set; }
        public GetMedicalReportByIDQuery(int id) => Id = id;
    }
}