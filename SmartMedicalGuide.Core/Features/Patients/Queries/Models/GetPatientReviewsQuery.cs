using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Models
{
    public class GetPatientReviewsQuery : IRequest<Response<object>>
    {
        public int PatientId { get; set; }
        public GetPatientReviewsQuery(int patientId) => PatientId = patientId;
    }
}