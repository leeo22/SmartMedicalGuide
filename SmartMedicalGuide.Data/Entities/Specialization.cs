using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Specialization
    {
        [Key]
        public int SpecializationId { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<Doctor>? Doctors { get; set; }
    }

}
