using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Data.Entities
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }

        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
