using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Chats.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Chats.Queries.Models
{
    public class GetChatByIDQuery : IRequest<Response<GetSingleChatResponse>>
    {
        public int Id { get; set; }
        public GetChatByIDQuery(int id) => Id = id;
    }
}