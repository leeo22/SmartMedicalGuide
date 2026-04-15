using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Specializations.Commands.Models
{
    public class DeleteSpecializationCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteSpecializationCommand(int id)
        {
            Id = id;

        }
    }
}
