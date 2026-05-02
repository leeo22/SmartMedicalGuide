using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.ChatParticipants.Commands.Models
{
    public class RemoveParticipantFromChatCommand : IRequest<Response<string>>
    {
        public int ChatId { get; set; }
        public int UserId { get; set; }
    }
}