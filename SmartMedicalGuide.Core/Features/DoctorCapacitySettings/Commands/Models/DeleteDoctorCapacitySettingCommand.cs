using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Commands.Models
{
    public class DeleteDoctorCapacitySettingCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteDoctorCapacitySettingCommand(int id) => Id = id;
    }
}