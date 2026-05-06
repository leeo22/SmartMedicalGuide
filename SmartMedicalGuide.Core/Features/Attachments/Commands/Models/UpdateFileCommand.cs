using MediatR;
using Microsoft.AspNetCore.Http;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Attachments.Commands.Models
{
    public class UpdateFileCommand : IRequest<Response<string>>
    {
        public int AttachmentId { get; set; }
        public IFormFile File { get; set; }
    }
}