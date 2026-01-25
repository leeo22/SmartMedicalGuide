using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Clinic
    {
        public int ClinicId { get; set; }

        [Required]
        public string ClinicName { get; set; }

        public string Location { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }

}
