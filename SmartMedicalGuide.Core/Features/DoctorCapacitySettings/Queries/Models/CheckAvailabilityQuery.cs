using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Queries.Models
{
    public class CheckAvailabilityQuery : IRequest<Response<bool>>
    {
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}