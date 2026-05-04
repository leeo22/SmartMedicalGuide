using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Models
{
    public class GetDoctorTodayAppointmentsQuery : IRequest<Response<List<GetDoctorAppointmentListResponse>>>
    {
        public int DoctorId { get; set; }
    }
}