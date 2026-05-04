using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Chat
    {
        [Key]
        public int ChatId { get; set; }

        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public DateTime? CreatedAt { get; set; }

        [MaxLength(200)]
        public string ChatName { get; set; } = string.Empty;
        public bool IsGroup { get; set; } = false;  // هل هي محادثة جماعية؟
        public string? LastMessage { get; set; }  // آخر رسالة (للعرض السريع)
        public DateTime? LastMessageAt { get; set; }  // وقت آخر رسالة
        public bool IsActive { get; set; } = true;  // هل المحادثة نشطة؟


        public ICollection<Message>? Messages { get; set; }
        public ICollection<ChatParticipant>? Participants { get; set; }  // ✅ كيان جديد
    }



}
