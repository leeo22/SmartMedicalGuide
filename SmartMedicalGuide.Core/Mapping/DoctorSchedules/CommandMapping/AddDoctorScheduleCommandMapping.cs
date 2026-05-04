using SmartMedicalGuide.Core.Features.DoctorSchedules.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.DoctorSchedules
{
    public partial class DoctorScheduleProfile
    {
        public void AddDoctorScheduleCommandMapping()
        {
            CreateMap<AddDoctorScheduleCommand, DoctorSchedule>()
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                .ForMember(dest => dest.DayOfWeek, opt => opt.MapFrom(src => src.DayOfWeek))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.BreakStartTime, opt => opt.MapFrom(src => src.BreakStartTime))
                .ForMember(dest => dest.BreakEndTime, opt => opt.MapFrom(src => src.BreakEndTime))
                .ForMember(dest => dest.MaxAppointmentsPerSlot, opt => opt.MapFrom(src => src.MaxAppointmentsPerSlot))
                .ForMember(dest => dest.SlotDuration, opt => opt.MapFrom(src => src.SlotDuration));
        }
    }
}