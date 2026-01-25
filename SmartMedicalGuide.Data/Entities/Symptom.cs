using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Symptom
    {
        [Key]
        public int SymptomId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
