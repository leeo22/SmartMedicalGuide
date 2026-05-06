using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Attachments.Commands.Models
{
    public class DeleteFileCommand : IRequest<Response<string>>
    {
        public int AttachmentId { get; set; }
    }
}