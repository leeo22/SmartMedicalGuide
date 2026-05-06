using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Labs.Commands.Models
{
    public class DeleteLabCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteLabCommand(int id) => Id = id;
    }
}