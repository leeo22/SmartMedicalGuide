using SmartMedicalGuide.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMedicalGuide.Data.Entities
{
    public class DiagnosisHistory
    {
        [Key]
        public int DiagnosisId { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        [Required]
        public string? Symptoms { get; set; }

        public string? AiDiagnosis { get; set; }
        public string? AiCause { get; set; }
        public string? SpecialtyName { get; set; }
        public double? Confidence { get; set; }
        public int? ResponseTimeMs { get; set; }
        public bool IsFromFallback { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? SelectedDoctorId { get; set; }

        [ForeignKey("SelectedDoctorId")]
        public virtual Doctor? SelectedDoctor { get; set; }
    }
}