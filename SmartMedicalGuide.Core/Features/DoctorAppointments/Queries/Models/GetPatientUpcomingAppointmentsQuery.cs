using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Models
{
    public class GetPatientUpcomingAppointmentsQuery : IRequest<Response<List<GetDoctorAppointmentListResponse>>>
    {
        public int PatientId { get; set; }
    }
}