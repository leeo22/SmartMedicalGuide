using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Models
{
    public class GetPatientUpcomingAppointmentsQuery : IRequest<Response<object>>
    {
        public int PatientId { get; set; }
        public GetPatientUpcomingAppointmentsQuery(int patientId) => PatientId = patientId;
    }
}