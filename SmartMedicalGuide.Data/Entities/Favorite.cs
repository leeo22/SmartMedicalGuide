using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }

        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
    }
}
