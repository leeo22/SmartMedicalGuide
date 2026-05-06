using SmartMedicalGuide.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Attachment
    {
        [Key]
        public int AttachmentId { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        [Required]
        [MaxLength(500)]
        public string? FilePath { get; set; }

        // ✅ الحقول الجديدة المضافة
        [Required]
        [MaxLength(255)]
        public string? FileName { get; set; }

        public long? FileSize { get; set; }

        [MaxLength(100)]
        public string? ContentType { get; set; }

        public bool IsDeleted { get; set; } = false;

        public int? RelatedEntityId { get; set; }

        [MaxLength(100)]
        public string? RelatedEntityType { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}