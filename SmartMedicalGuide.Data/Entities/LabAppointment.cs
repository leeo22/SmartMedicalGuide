using SmartMedicalGuide.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMedicalGuide.Data.Entities
{
    public class LabAppointment
    {
        [Key]
        public int LabAppointmentId { get; set; }

        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int LabId { get; set; }
        public Lab? Lab { get; set; }

        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string? TestType { get; set; }
        public string? Status { get; set; }
        public decimal? Price { get; set; }

        public Payment? Payment { get; set; }

        // حذف منطقي
        public bool IsDeleted { get; set; } = false;

        // مصدر الحجز (Online, Phone, Walk-in)
        [MaxLength(50)]
        public string? BookingSource { get; set; }

        // ملاحظات إضافية على الموعد
        public string? Notes { get; set; }

        // سبب إلغاء الموعد
        public string? CancellationReason { get; set; }

        // معرف المستخدم الذي قام بإعادة الجدولة
        public int? RescheduledByUserId { get; set; }

        // Navigation Property للمستخدم الذي قام بإعادة الجدولة
        [ForeignKey("RescheduledByUserId")]
        public virtual User? RescheduledByUser { get; set; }
    }

}
