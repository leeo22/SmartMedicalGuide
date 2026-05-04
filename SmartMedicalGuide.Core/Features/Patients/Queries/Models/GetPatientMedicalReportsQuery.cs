using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Models
{
    public class GetPatientMedicalReportsQuery : IRequest<Response<object>>
    {
        public int PatientId { get; set; }
        public GetPatientMedicalReportsQuery(int patientId) => PatientId = patientId;
    }
}