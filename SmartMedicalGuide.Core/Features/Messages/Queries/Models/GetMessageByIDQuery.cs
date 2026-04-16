using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Messages.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Messages.Queries.Models
{
    public class GetMessageByIDQuery : IRequest<Response<GetSingleMessageResponse>>
    {
        public int Id { get; set; }
        public GetMessageByIDQuery(int id) => Id = id;
    }
}