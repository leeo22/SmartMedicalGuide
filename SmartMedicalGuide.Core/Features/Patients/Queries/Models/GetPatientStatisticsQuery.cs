using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Models
{
    public class GetPatientStatisticsQuery : IRequest<Response<object>>
    {
        public int PatientId { get; set; }
        public GetPatientStatisticsQuery(int patientId) => PatientId = patientId;
    }
}