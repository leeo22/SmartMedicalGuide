using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.MedicalReports.Queries.Results;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Queries.Models
{
    public class GetPatientMedicalHistoryQuery : IRequest<Response<List<GetPatientMedicalHistoryResponse>>>
    {
        public int PatientId { get; set; }
    }
}