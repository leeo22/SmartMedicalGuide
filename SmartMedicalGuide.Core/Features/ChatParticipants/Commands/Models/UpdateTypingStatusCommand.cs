using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.ChatParticipants.Commands.Models
{
    public class UpdateTypingStatusCommand : IRequest<Response<string>>
    {
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public bool IsTyping { get; set; }
    }
}