using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Attachments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Attachments.Queries.Models
{
    public class GetAttachmentByIDQuery : IRequest<Response<GetSingleAttachmentResponse>>
    {
        public int Id { get; set; }
        public GetAttachmentByIDQuery(int id) => Id = id;
    }
}