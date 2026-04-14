using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Data.Entities
{
    public class SearchHistory
    {
        [Key]
        public int SearchId { get; set; }

        public int UserId { get; set; }
        public string Keyword { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
