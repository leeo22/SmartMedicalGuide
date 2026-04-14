using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Data.Entities
{
    public class DoctorSchedule
    {
        [Key]
        public int ScheduleId { get; set; }

        public int DoctorId { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime StartTime  { get; set; }
        public DateTime EndTime { get; set; }

    }
}
