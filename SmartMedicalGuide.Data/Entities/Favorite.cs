using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMedicalGuide.Data.Entities
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }

        [Required]
        public int PatientId { get; set; }
        public virtual Patient? Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }

        // تاريخ إضافة الدكتور إلى المفضلة
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // حذف منطقي
        public bool IsDeleted { get; set; } = false;
    }
}