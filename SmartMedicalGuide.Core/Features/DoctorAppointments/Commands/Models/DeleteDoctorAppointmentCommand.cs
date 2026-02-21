using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models
{
    public class DeleteDoctorAppointmentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteDoctorAppointmentCommand(int id)
        {
            Id = id;
        }
    }
}
