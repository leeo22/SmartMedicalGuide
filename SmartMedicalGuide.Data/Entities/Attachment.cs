using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Attachment
    {
        [Key]
        public int AttachmentId { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public string? FilePath { get; set; }
        public DateTime? UploadedAt { get; set; }
    }
}
