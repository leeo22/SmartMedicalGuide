using System.ComponentModel.DataAnnotations;
using SmartMedicalGuide.Data.Entities.Identity;

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

        public ICollection<DoctorAppointment>? DoctorAppointments { get; set; }
        public ICollection<LabAppointment>? LabAppointments { get; set; }
    }


}
