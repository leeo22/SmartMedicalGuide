using SmartMedicalGuide.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartMedicalGuide.Data.Entities
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        //[ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public string? Bio { get; set; }

        public string? LicenseNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ConsultationPrice { get; set; }

        public string? VerificationStatus { get; set; }

        public string? AvailableTimes { get; set; }

        //[ForeignKey("Specialization")]
        public int? SpecializationId { get; set; }
        public virtual Specialization? Specialization { get; set; }

        // ✅ الحقول الإضافية المضافة
        public bool IsAvailableForBooking { get; set; } = true;

        public int? YearsOfExperience { get; set; }

        public string? Gender { get; set; }  // "Male", "Female"

        public string? ProfileImageUrl { get; set; }

        public bool IsDeleted { get; set; } = false;

        // Navigation Properties
        public virtual ICollection<Clinic>? Clinics { get; set; }
        public virtual ICollection<DoctorSchedule>? DoctorSchedules { get; set; }
        public virtual ICollection<DoctorAppointment>? DoctorAppointments { get; set; }
        public virtual ICollection<Prescription>? Prescriptions { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<Chat>? ChatsAsDoctor { get; set; }
        public virtual ICollection<DoctorCapacitySetting>? DoctorCapacitySettings { get; set; }
    }
}