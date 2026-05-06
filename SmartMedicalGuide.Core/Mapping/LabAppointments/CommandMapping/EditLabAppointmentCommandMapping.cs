using SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.LabAppointments
{
    public partial class LabAppointmentProfile
    {
        public void EditLabAppointmentCommandMapping()
        {
            CreateMap<EditLabAppointmentCommand, LabAppointment>()
                .ForMember(dest => dest.LabAppointmentId, opt => opt.MapFrom(src => src.LabAppointmentId))
                .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => src.AppointmentDate))
                .ForMember(dest => dest.TestType, opt => opt.MapFrom(src => src.TestType))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.BookingSource, opt => opt.MapFrom(src => src.BookingSource));
        }
    }
}