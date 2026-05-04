using SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.DoctorAppointments
{
    public partial class DoctorAppointmentProfile
    {
        public void GetSingleDoctorAppointmentResponseMapping()
        {
            CreateMap<DoctorAppointment, GetSingleDoctorAppointmentResponse>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.FullName : src.FullName))
                .ForMember(dest => dest.PatientEmail, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.Email : null))
                .ForMember(dest => dest.PatientPhone, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.PhoneNumber : src.PhoneNumber))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.FullName : null))
                .ForMember(dest => dest.DoctorEmail, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.Email : null))
                .ForMember(dest => dest.DoctorPhone, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.PhoneNumber : null));
        }
    }
}