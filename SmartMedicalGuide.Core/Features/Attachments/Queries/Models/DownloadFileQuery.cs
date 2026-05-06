using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Attachments.Queries.Models
{
    public class DownloadFileQuery : IRequest<Response<(string filePath, string fileName, string contentType)>>
    {
        public int AttachmentId { get; set; }
        public DownloadFileQuery(int attachmentId) => AttachmentId = attachmentId;
    }
}