using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Models
{
    public class GetDoctorAppointmentsCountQuery : IRequest<Response<int>>
    {
        public int DoctorId { get; set; }
    }
}