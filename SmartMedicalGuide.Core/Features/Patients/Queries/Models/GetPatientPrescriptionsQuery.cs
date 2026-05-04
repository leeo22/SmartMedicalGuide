using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Models
{
    public class GetPatientPrescriptionsQuery : IRequest<Response<object>>
    {
        public int PatientId { get; set; }
        public GetPatientPrescriptionsQuery(int patientId) => PatientId = patientId;
    }
}