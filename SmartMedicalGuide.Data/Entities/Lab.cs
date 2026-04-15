using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Lab
    {
        [Key]
        public int LabId { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public string? CenterName { get; set; }
        public string? CenterType { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Location { get; set; }
        public string? LicenseNumber { get; set; }
        public string? VerificationStatus { get; set; }

        public ICollection<LabService>? LabServices { get; set; }
    }

}
