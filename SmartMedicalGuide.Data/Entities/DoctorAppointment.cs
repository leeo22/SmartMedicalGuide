using SmartMedicalGuide.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMedicalGuide.Data.Entities
{
    public class DoctorAppointment
    {
        [Key]
        public int AppointmentId { get; set; }

        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public string? AppointmentType { get; set; }

        public string? BookingSource { get; set; } // Electronic / Clinic

        public string? FullName { get; set; }

        public int? Age { get; set; }

        public string? Gender { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public DateTime? OriginalAppointmentDate { get; set; }

        public DateTime? NewAppointmentDate { get; set; }

        public string? PostponeReason { get; set; }
        // Soft Delete
        public bool IsDeleted { get; set; } = false;

        // سبب الإلغاء (اختياري)
        public string? CancellationReason { get; set; }

        // معرف المستخدم الذي قام بإعادة الجدولة (Admin أو Doctor أو Patient)
        public int? RescheduledByUserId { get; set; }

        // Navigation Property للمستخدم الذي قام بإعادة الجدولة
        [ForeignKey("RescheduledByUserId")]
        public virtual User? RescheduledByUser { get; set; }

        public bool IsPostponed { get; set; } = false;

        public decimal? Price { get; set; }

        public string? Status { get; set; }

        public Payment? Payment { get; set; }
        public virtual ICollection<Prescription>? Prescriptions { get; set; }

    }

}
