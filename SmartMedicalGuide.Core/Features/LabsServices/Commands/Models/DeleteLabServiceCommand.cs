using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.LabsServices.Commands.Models
{
    public class DeleteLabServiceCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public DeleteLabServiceCommand(int id)
        {
            Id = id;
        }
    }
}