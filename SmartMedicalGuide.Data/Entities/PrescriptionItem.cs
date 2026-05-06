using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class PrescriptionItem
    {
        [Key]
        public int ItemId { get; set; }

        public int PrescriptionId { get; set; }
        public Prescription? Prescription { get; set; }

        public string? MedicineName { get; set; }
        public string? Dosage { get; set; }
        public string? Duration { get; set; }


        public bool IsDeleted { get; set; } = false;

        [MaxLength(100)]
        public string? Frequency { get; set; }

        public string? Instructions { get; set; }

        public int? Quantity { get; set; }
    }
}
