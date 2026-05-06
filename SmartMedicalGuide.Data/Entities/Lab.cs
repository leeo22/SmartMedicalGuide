using SmartMedicalGuide.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMedicalGuide.Data.Entities
{
    public class Lab
    {
        [Key]
        public int LabId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string? CenterName { get; set; }
        public string? CenterType { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Location { get; set; }
        public string? LicenseNumber { get; set; }
        public string? VerificationStatus { get; set; }

        // هل المختبر نشط؟
        public bool IsActive { get; set; } = true;

        // حذف منطقي
        public bool IsDeleted { get; set; } = false;

        // خط العرض (للمختبرات القريبة)
        [Column(TypeName = "decimal(10,8)")]
        public decimal? Latitude { get; set; }

        // خط الطول (للمختبرات القريبة)
        [Column(TypeName = "decimal(11,8)")]
        public decimal? Longitude { get; set; }

        // رابط صورة المختبر
        [MaxLength(500)]
        public string? LabImageUrl { get; set; }

        // وصف المختبر
        public string? Description { get; set; }

        // البريد الإلكتروني للمختبر
        [MaxLength(256)]
        public string? Email { get; set; }

        // ساعات العمل (يمكن تخزينها كـ JSON)
        public string? WorkingHours { get; set; }

        public ICollection<LabService>? LabServices { get; set; }
        public ICollection<LabAppointment>? LabAppointments { get; set; }
    }

}
