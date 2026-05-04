using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorSchedules.Commands.Models
{
    public class EditDoctorScheduleCommand : IRequest<Response<string>>
    {
        public int ScheduleId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? BreakStartTime { get; set; }
        public TimeSpan? BreakEndTime { get; set; }
        public int MaxAppointmentsPerSlot { get; set; }
        public int SlotDuration { get; set; }
        public bool IsActive { get; set; }
    }
}