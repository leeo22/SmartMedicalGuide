using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Models
{
    public class GetPatientFavoriteDoctorsQuery : IRequest<Response<object>>
    {
        public int PatientId { get; set; }
        public GetPatientFavoriteDoctorsQuery(int patientId) => PatientId = patientId;
    }
}