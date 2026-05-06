using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public int PatientId { get; set; }
        public virtual Patient? Patient { get; set; }

        [Required]
        [MaxLength(50)]
        public string? TargetType { get; set; }  // "Doctor" or "Lab"

        [Required]
        public int TargetId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(2000)]
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // ✅ الحقول الجديدة المضافة
        public bool IsDeleted { get; set; } = false;

        public bool IsEdited { get; set; } = false;

        public DateTime? LastUpdatedAt { get; set; }
    }
}