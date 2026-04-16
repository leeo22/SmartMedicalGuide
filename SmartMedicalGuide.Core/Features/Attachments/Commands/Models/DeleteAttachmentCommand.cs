using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Attachments.Commands.Models
{
    public class DeleteAttachmentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteAttachmentCommand(int id) => Id = id;
    }
}