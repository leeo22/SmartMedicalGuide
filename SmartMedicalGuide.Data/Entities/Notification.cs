using System.ComponentModel.DataAnnotations;
using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Data.Entities
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public string? Title { get; set; }
        public string? Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }

        // حذف منطقي
        public bool IsDeleted { get; set; } = false;

        // نوع الإشعار (Appointment, Payment, Report, System, Message)
        [MaxLength(50)]
        public string? NotificationType { get; set; }

        // معرف الكيان المرتبط (مثلاً AppointmentId)
        public int? RelatedEntityId { get; set; }

        // نوع الكيان المرتبط (DoctorAppointment, Payment, MedicalReport)
        [MaxLength(100)]
        public string? RelatedEntityType { get; set; }

        // رابط الصورة الرمزية للإشعار
        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        // الرابط الذي يفتح عند النقر على الإشعار
        [MaxLength(500)]
        public string? ActionUrl { get; set; }
    }

}
