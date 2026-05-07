using SmartMedicalGuide.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        public string? Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(250)]
        public string? Address { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<DoctorAppointment>? DoctorAppointments { get; set; }
        public virtual ICollection<LabAppointment>? LabAppointments { get; set; }
        public virtual ICollection<Prescription>? Prescriptions { get; set; }
    }


}
