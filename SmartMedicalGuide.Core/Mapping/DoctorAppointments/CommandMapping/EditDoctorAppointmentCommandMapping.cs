using SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.DoctorAppointments
{
    public partial class DoctorAppointmentProfile
    {
        public void EditDoctorAppointmentCommandMapping()
        {
            CreateMap<EditDoctorAppointmentCommand, DoctorAppointment>()
                .ForMember(dest => dest.AppointmentId, opt => opt.MapFrom(src => src.AppointmentId))
                .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => src.AppointmentDate))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.AppointmentType, opt => opt.MapFrom(src => src.AppointmentType))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.IsPostponed, opt => opt.MapFrom(src => src.IsPostponed))
                .ForMember(dest => dest.NewAppointmentDate, opt => opt.MapFrom(src => src.NewAppointmentDate))
                .ForMember(dest => dest.OriginalAppointmentDate, opt => opt.MapFrom(src => src.OriginalAppointmentDate))
                .ForMember(dest => dest.PostponeReason, opt => opt.MapFrom(src => src.PostponeReason))
                .ForMember(dest => dest.CancellationReason, opt => opt.MapFrom(src => src.CancellationReason));
        }
    }
}