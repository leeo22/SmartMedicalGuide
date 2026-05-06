using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Attachments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Attachments.Queries.Models
{
    public class GetAttachmentByIdQuery : IRequest<Response<GetSingleAttachmentResponse>>
    {
        public int Id { get; set; }
        public GetAttachmentByIdQuery(int id) => Id = id;
    }
}