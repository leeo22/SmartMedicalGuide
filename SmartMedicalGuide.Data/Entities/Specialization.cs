using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Data.Entities
{
    public class Specialization
    {
        [Key]
        public int SpecializationId {  get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

    }
}
