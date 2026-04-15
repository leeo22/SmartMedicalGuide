using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Clinic
    {
        [Key]
        public int ClinicId { get; set; }
        public string? ClinicName { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }

        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }


    }

}
