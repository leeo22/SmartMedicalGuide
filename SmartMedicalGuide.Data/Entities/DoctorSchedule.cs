using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class DoctorSchedule
    {
        [Key]
        public int ScheduleId { get; set; }

        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public string? DayOfWeek { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
