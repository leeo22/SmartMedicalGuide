using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Commands.Models
{
    public class EditDoctorCapacitySettingCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public WorkDays WorkDays { get; set; }
        public BookingType BookingType { get; set; }
        public ShiftType ShiftType { get; set; }
        public int DailyCapacity { get; set; }
        public int MaxLimit { get; set; }
        public bool IsActive { get; set; }
    }
}