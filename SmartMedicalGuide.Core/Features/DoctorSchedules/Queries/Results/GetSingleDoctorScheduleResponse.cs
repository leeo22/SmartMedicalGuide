using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Features.DoctorSchedules.Queries.Results
{
    public class GetSingleDoctorScheduleResponse
    {
        public int ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorEmail { get; set; }
        public string DoctorPhone { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? BreakStartTime { get; set; }
        public TimeSpan? BreakEndTime { get; set; }
        public int MaxAppointmentsPerSlot { get; set; }
        public int SlotDuration { get; set; }
        public bool IsActive { get; set; }
        public ICollection<DoctorAppointment>? UpcomingAppointments { get; set; }
    }
}