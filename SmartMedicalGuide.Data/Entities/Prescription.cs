using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        public int DoctorAppointmentId { get; set; }
        public DoctorAppointment? DoctorAppointment { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public int PatientId { get; set; }

        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
