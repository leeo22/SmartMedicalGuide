using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Models
{
    public class GetDoctorAppointmentsByStatusQuery : IRequest<Response<List<GetDoctorAppointmentListResponse>>>
    {
        public string Status { get; set; }
    }
}