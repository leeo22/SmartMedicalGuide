using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.MedicalReports.Queries.Results;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Queries.Models
{
    public class GetMedicalReportByPatientIdQuery : IRequest<Response<List<GetMedicalReportListResponse>>>
    {
        public int PatientId { get; set; }
    }
}