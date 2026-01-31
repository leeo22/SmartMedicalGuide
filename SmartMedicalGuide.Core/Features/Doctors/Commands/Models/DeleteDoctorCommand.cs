using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Doctors.Commands.Models
{
    public class DeleteDoctorCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteDoctorCommand(int id)
        {
            Id = id;

        }
    }
}
