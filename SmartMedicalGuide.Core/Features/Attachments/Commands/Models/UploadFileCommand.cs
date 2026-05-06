using MediatR;
using Microsoft.AspNetCore.Http;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Attachments.Commands.Models
{
    public class UploadFileCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public IFormFile File { get; set; }
        public string? RelatedEntityType { get; set; }
        public int? RelatedEntityId { get; set; }
        public string? Description { get; set; }
    }
}