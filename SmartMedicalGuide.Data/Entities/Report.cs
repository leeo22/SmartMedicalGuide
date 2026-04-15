using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        public int ReporterUserId { get; set; }
        public User? ReporterUser { get; set; }

        public string? TargetType { get; set; }
        public int TargetId { get; set; }

        public string? Reason { get; set; }
        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
