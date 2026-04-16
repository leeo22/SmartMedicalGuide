using System.ComponentModel.DataAnnotations;
using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Data.Entities
{
    public class VerificationRequest
    {
        [Key]
        public int RequestId { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public string? DocumentType { get; set; }
        public string? DocumentImagePath { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
