using System.ComponentModel.DataAnnotations;
using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Data.Entities
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public int ChatId { get; set; }
        public Chat? Chat { get; set; }

        public int SenderId { get; set; }
        public User? Sender { get; set; }

        public string? Content { get; set; }
        public DateTime SentAt { get; set; }
    }
}
