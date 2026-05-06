using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Attachments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Attachments.Queries.Models
{
    public class GetAttachmentListQuery : IRequest<Response<List<GetAttachmentListResponse>>>
    {
        public int? UserId { get; set; }
        public string? RelatedEntityType { get; set; }
        public int? RelatedEntityId { get; set; }
    }
}