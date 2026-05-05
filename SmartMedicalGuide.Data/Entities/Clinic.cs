using SmartMedicalGuide.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMedicalGuide.Data.Entities
{
    public class Clinic
    {
        [Key]
        public int ClinicId { get; set; }
        public string? ClinicName { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }

        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        // هل العيادة نشطة؟
        public bool IsActive { get; set; } = true;

        // حذف منطقي
        public bool IsDeleted { get; set; } = false;

        // خط العرض (للعيادات القريبة)
        [Column(TypeName = "decimal(10,8)")]
        public decimal? Latitude { get; set; }

        // خط الطول (للعيادات القريبة)
        [Column(TypeName = "decimal(11,8)")]
        public decimal? Longitude { get; set; }

        // رابط صورة العيادة
        [MaxLength(500)]
        public string? ClinicImageUrl { get; set; }

        // وصف العيادة
        public string? Description { get; set; }

        // البريد الإلكتروني للعيادة
        [MaxLength(256)]
        public string? Email { get; set; }

        // وقت فتح العيادة
        public TimeSpan? OpeningTime { get; set; }

        // وقت إغلاق العيادة
        public TimeSpan? ClosingTime { get; set; }


    }

}
