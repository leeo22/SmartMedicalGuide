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



        public bool IsDeleted { get; set; } = false;
        public virtual Patient? Patient { get; set; }

        public string? Notes { get; set; }

        public DateTime? FollowUpDate { get; set; }

        [MaxLength(50)]
        public string? Status { get; set; } = "Active";

        // Navigation Properties
        public virtual ICollection<PrescriptionItem>? PrescriptionItems { get; set; }
    }

}
