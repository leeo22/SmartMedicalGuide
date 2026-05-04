using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Models
{
    public class GetPatientPastAppointmentsQuery : IRequest<Response<object>>
    {
        public int PatientId { get; set; }
        public GetPatientPastAppointmentsQuery(int patientId) => PatientId = patientId;
    }
}