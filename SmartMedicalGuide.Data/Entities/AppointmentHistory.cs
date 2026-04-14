using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Data.Entities
{
    public class AppointmentHistory
    {
        [Key]
        public int HistoryId { get; set; }

        public int AppointmentId { get; set; }
        public string Status { get; set; }
        public DateTime ChangedAt { get; set; }

    }
}
