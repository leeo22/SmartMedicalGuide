using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Models
{
    public class GetPatientPaymentHistoryQuery : IRequest<Response<object>>
    {
        public int PatientId { get; set; }
        public GetPatientPaymentHistoryQuery(int patientId) => PatientId = patientId;
    }
}