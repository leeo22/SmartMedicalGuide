using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Models
{
    public class GetPatientAppointmentsQuery : IRequest<Response<object>>
    {
        public int PatientId { get; set; }
        public GetPatientAppointmentsQuery(int patientId) => PatientId = patientId;
    }
}