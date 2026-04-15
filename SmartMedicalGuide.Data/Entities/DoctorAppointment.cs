using System.ComponentModel.DataAnnotations;

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
        public string? FullName { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }

        public DateTime? AppointmentDate { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }

        public Payment? Payment { get; set; }
    }

}
