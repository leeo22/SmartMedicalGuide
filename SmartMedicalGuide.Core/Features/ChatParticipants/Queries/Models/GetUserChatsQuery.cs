using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.ChatParticipants.Queries.Results;

namespace SmartMedicalGuide.Core.Features.ChatParticipants.Queries.Models
{
    public class GetUserChatsQuery : IRequest<Response<List<UserChatResponse>>>
    {
        public int UserId { get; set; }
        public GetUserChatsQuery(int userId) => UserId = userId;
    }
}