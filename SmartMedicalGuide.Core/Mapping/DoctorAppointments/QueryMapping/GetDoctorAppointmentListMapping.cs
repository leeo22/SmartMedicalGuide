using SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.DoctorAppointments
{
    public partial class DoctorAppointmentProfile
    {
        public void GetDoctorAppointmentListMapping()
        {
            CreateMap<DoctorAppointment, GetDoctorAppointmentListRespones>()
                .ForMember(dest => dest.DoctorName, opt => opt
                    .MapFrom(src => src.Doctor.User.FullName)) // الاسم من جدول User للدكتور
                .ForMember(dest => dest.AppointmentDate, opt => opt
                    .MapFrom(src => src.AppointmentDate))
                .ForMember(dest => dest.Price, opt => opt
                    .MapFrom(src => src.Doctor.ConsultationPrice))
                .ForMember(dest => dest.PaymentStatus, opt => opt
                    .MapFrom(src => src.Payment))
                .ForMember(dest => dest.Status, opt => opt
                    .MapFrom(src => src.Status));
        }




    }
}

