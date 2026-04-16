using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Messages.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Messages.Queries.Models
{
    public class GetMessageListQuery : IRequest<Response<List<GetMessageListResponse>>>
    {
        public int? ChatId { get; set; }
        public int? SenderId { get; set; }
        public GetMessageListQuery() { }
        public GetMessageListQuery(int? chatId, int? senderId)
        {
            ChatId = chatId;
            SenderId = senderId;
        }
    }
}