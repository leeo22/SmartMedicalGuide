using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class UserSession
    {
        [Key]
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
    }
}
