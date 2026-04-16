using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Messages.Commands.Models
{
    public class DeleteMessageCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteMessageCommand(int id) => Id = id;
    }
}