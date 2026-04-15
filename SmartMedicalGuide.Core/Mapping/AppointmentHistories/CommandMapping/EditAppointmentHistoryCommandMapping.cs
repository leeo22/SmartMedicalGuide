using SmartMedicalGuide.Core.Features.AppointmentHistories.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.AppointmentHistories
{
    public partial class AppointmentHistoryProfile
    {
        public void EditAppointmentHistoryCommandMapping()
        {
            CreateMap<EditAppointmentHistoryCommand, AppointmentHistory>()
                .ForMember(dest => dest.HistoryId, opt => opt.MapFrom(src => src.HistoryId))
                .ForMember(dest => dest.AppointmentId, opt => opt.MapFrom(src => src.AppointmentId))
                .ForMember(dest => dest.AppointmentType, opt => opt.MapFrom(src => src.AppointmentType))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.ChangedAt, opt => opt.MapFrom(src => src.ChangedAt));
        }
    }
}