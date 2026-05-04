using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Models
{
    public class CheckDoctorAvailabilityQuery : IRequest<Response<bool>>
    {
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}