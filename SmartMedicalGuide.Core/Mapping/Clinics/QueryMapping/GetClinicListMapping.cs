using SmartMedicalGuide.Core.Features.Clinics.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Clinics
{
    public partial class ClinicProfile
    {
        public void GetClinicListResponseMapping()
        {
            CreateMap<Clinic, GetClinicListResponse>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor != null && src.Doctor.User != null ? src.Doctor.User.FullName : null));
        }
    }
}