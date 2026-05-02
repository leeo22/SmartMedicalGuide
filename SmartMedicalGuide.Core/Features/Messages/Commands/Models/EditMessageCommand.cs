using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Messages.Commands.Models
{
    public class EditMessageCommand : IRequest<Response<string>>
    {
        public int MessageId { get; set; }
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }

        // ✅ الحقول الجديدة
        public bool IsRead { get; set; }
        public bool IsDeleted { get; set; }  // حذف منطقي
        public int? ReplyToMessageId { get; set; }
        public string? AttachmentUrl { get; set; }
    }
}