using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorAppointmentByIDQuery : IRequest<Response<GetSingleDoctorAppointmentResponse>>
    {
        public int Id { get; set; }
        public GetDoctorAppointmentByIDQuery(int id)
        {
            Id = id;
        }
    }
}
