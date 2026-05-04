using SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.DoctorCapacitySettings
{
    public partial class DoctorCapacitySettingProfile
    {
        public void AddDoctorCapacitySettingCommandMapping()
        {
            CreateMap<AddDoctorCapacitySettingCommand, DoctorCapacitySetting>()
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId))
                .ForMember(dest => dest.WorkDays, opt => opt.MapFrom(src => src.WorkDays))
                .ForMember(dest => dest.BookingType, opt => opt.MapFrom(src => src.BookingType))
                .ForMember(dest => dest.ShiftType, opt => opt.MapFrom(src => src.ShiftType))
                .ForMember(dest => dest.DailyCapacity, opt => opt.MapFrom(src => src.DailyCapacity))
                .ForMember(dest => dest.MaxLimit, opt => opt.MapFrom(src => src.MaxLimit))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}