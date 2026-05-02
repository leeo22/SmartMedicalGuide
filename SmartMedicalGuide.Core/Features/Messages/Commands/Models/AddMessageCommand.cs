using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Messages.Commands.Models
{
    public class AddMessageCommand : IRequest<Response<string>>
    {
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;

        // ✅ الحقول الجديدة
        public bool IsRead { get; set; } = false;  // هل قرئت؟
        public int? ReplyToMessageId { get; set; }  // الرد على رسالة
        public string? AttachmentUrl { get; set; }  // رابط المرفق
    }
}