using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class SearchHistory
    {
        [Key]
        public int SearchId { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public string? Keyword { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
