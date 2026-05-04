using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Doctors.Commands.Models
{
    public class ToggleAvailableForBookingCommand : IRequest<Response<string>>
    {
        public int DoctorId { get; set; }
        public bool IsAvailableForBooking { get; set; }
    }
}