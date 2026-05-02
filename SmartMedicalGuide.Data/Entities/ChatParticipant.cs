using SmartMedicalGuide.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class ChatParticipant
    {
        [Key]
        public int Id { get; set; }

        public int ChatId { get; set; }
        public Chat? Chat { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastSeenAt { get; set; }  // آخر مرة شاهد فيها المحادثة
        public bool IsTyping { get; set; } = false;  // هل يكتب الآن؟
        public bool IsMuted { get; set; } = false;  // هل كتم الإشعارات؟
        public DateTime? MutedUntil { get; set; }  // كتم مؤقت حتى تاريخ
        public bool IsAdmin { get; set; } = false;  // هل هو مشرف في المحادثة الجماعية؟
    }
}