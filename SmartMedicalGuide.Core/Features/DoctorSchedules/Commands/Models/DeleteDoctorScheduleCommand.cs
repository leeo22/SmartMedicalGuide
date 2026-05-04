using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorSchedules.Commands.Models
{
    public class DeleteDoctorScheduleCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteDoctorScheduleCommand(int id) => Id = id;
    }
}