using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorSchedules.Commands.Models
{
    public class AddDoctorScheduleCommand : IRequest<Response<string>>
    {
        public int DoctorId { get; set; }
        public string DayOfWeek { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? BreakStartTime { get; set; }
        public TimeSpan? BreakEndTime { get; set; }
        public int MaxAppointmentsPerSlot { get; set; } = 1;
        public int SlotDuration { get; set; } = 30;
    }
}