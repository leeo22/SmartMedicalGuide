using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class DoctorCapacitySetting
    {
        [Key]
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public Doctor? Doctor { get; set; }

        public WorkDays WorkDays { get; set; }
        public BookingType BookingType { get; set; }
        public ShiftType ShiftType { get; set; }
        public DateTime CreatedAt { get; set; }
        public int DailyCapacity { get; set; }

        public int MaxLimit { get; set; }

        public bool IsActive { get; set; } = true;
    }
    public enum WorkDays
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7,
        Weekdays = 8,      // Mon-Fri
        Weekends = 9,      // Sat-Sun
        Everyday = 10
    }

    public enum BookingType
    {
        Online = 1,
        Offline = 2,
        Both = 3
    }

    public enum ShiftType
    {
        Morning = 1,
        Evening = 2,
        FullDay = 3
    }
}
