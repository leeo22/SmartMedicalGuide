using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Chat
    {
        [Key]
        public int ChatId { get; set; }

        public int? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public DateTime? CreatedAt { get; set; }

        public ICollection<Message>? Messages { get; set; }
    }



}
