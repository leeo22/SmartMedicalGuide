using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Queries.Models
{
    public class CheckLabAvailabilityQuery : IRequest<Response<bool>>
    {
        public int LabId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}