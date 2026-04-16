using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Chats.Commands.Models
{
    public class DeleteChatCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteChatCommand(int id) => Id = id;
    }
}