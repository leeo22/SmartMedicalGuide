using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.ChatParticipants.Queries.Results;

namespace SmartMedicalGuide.Core.Features.ChatParticipants.Queries.Models
{
    public class GetChatParticipantsQuery : IRequest<Response<List<ChatParticipantResponse>>>
    {
        public int ChatId { get; set; }
        public GetChatParticipantsQuery(int chatId) => ChatId = chatId;
    }
}