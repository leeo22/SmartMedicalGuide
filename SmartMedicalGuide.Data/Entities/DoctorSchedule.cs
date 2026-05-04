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

        // هل الجدول نشط حالياً؟
        public bool IsActive { get; set; } = true;

        // حذف منطقي
        public bool IsDeleted { get; set; } = false;

        // وقت بداية فترة الراحة (مثل: 13:00)
        public TimeSpan? BreakStartTime { get; set; }

        // وقت نهاية فترة الراحة (مثل: 14:00)
        public TimeSpan? BreakEndTime { get; set; }

        // عدد المواعيد القصوى في الفترة الزمنية الواحدة
        public int MaxAppointmentsPerSlot { get; set; } = 1;

        // مدة الموعد بالدقائق (افتراضي 30 دقيقة)
        public int SlotDuration { get; set; } = 30;
    }
}
