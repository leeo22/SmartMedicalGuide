using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class AppointmentHistory
    {
        [Key]
        public int HistoryId { get; set; }

        public int? AppointmentId { get; set; }
        public string? AppointmentType { get; set; }
        public string? Status { get; set; }
        public DateTime? ChangedAt { get; set; }

    }
}
