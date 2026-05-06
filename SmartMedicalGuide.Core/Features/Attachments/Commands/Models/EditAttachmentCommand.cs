using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Attachments.Commands.Models
{
    public class EditAttachmentCommand : IRequest<Response<string>>
    {
        public int AttachmentId { get; set; }
        public string? Description { get; set; }
        public string? RelatedEntityType { get; set; }
        public int? RelatedEntityId { get; set; }
    }
}