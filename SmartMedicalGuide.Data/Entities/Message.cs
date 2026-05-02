using SmartMedicalGuide.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMedicalGuide.Data.Entities
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public int ChatId { get; set; }
        public Chat? Chat { get; set; }

        public int SenderId { get; set; }
        public User? Sender { get; set; }

        public string? Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; } = false;  // هل قرأها المستلم؟
        public DateTime? ReadAt { get; set; }  // متى قرأها؟
        public bool IsDeleted { get; set; } = false;  // حذف منطقي
        public int? ReplyToMessageId { get; set; }  // الرد على رسالة معينة
        public string? AttachmentUrl { get; set; }  // رابط المرفق (صورة/ملف)

        // Navigation property للرد على رسالة
        [ForeignKey("ReplyToMessageId")]
        public Message? ReplyToMessage { get; set; }
    }
}
