using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        public int PatientId { get; set; }
        public string TargetType { get; set; }
        public int TargetId { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
