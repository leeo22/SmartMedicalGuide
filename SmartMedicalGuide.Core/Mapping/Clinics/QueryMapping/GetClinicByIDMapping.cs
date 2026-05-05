using SmartMedicalGuide.Core.Features.Clinics.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Clinics
{
    public partial class ClinicProfile
    {
        public void GetSingleClinicResponseMapping()
        {
            CreateMap<Clinic, GetSingleClinicResponse>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.FullName : null))
                .ForMember(dest => dest.DoctorEmail, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.Email : null))
                .ForMember(dest => dest.DoctorPhone, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.PhoneNumber : null));
        }
    }
}