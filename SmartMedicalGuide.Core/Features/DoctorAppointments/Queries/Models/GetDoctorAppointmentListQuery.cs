using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorAppointmentListQuery : IRequest<Response<List<GetDoctorAppointmentListRespones>>>
    {

    }
}
