using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMedicalGuide.Data.Entities
{
    public class LabService
    {
        [Key]
        public int ServiceId { get; set; }

        public int LabId { get; set; }
        public Lab? Lab { get; set; }

        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        // هل الخدمة نشطة؟
        public bool IsActive { get; set; } = true;

        // حذف منطقي
        public bool IsDeleted { get; set; } = false;

        // تصنيف الخدمة (Blood Test, X-Ray, MRI, Ultrasound, إلخ)
        [MaxLength(100)]
        public string? Category { get; set; }

        // مدة الخدمة بالدقائق
        public int? Duration { get; set; }

        // رابط صورة الخدمة
        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        // نسبة الخصم على الخدمة
        [Column(TypeName = "decimal(5,2)")]
        public decimal? DiscountPercentage { get; set; }
    }

}
