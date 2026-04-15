using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class LabService
    {
        [Key]
        public int ServiceId { get; set; }

        public int LabId { get; set; }
        public Lab? Lab { get; set; }

        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }

}
