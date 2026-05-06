using SmartMedicalGuide.Core.Features.LabAppointments.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.LabAppointments
{
    public partial class LabAppointmentProfile
    {
        public void GetSingleLabAppointmentResponseMapping()
        {
            CreateMap<LabAppointment, GetSingleLabAppointmentResponse>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.FullName : src.FullName))
                .ForMember(dest => dest.PatientEmail, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.Email : null))
                .ForMember(dest => dest.PatientPhone, opt => opt.MapFrom(src => src.Patient != null && src.Patient.User != null ? src.Patient.User.PhoneNumber : src.PhoneNumber))
                .ForMember(dest => dest.LabName, opt => opt.MapFrom(src => src.Lab != null && src.Lab.User != null ? src.Lab.User.FullName : null))
                .ForMember(dest => dest.LabEmail, opt => opt.MapFrom(src => src.Lab != null && src.Lab.User != null ? src.Lab.User.Email : null))
                .ForMember(dest => dest.LabPhone, opt => opt.MapFrom(src => src.Lab != null ? src.Lab.PhoneNumber : null));
        }
    }
}