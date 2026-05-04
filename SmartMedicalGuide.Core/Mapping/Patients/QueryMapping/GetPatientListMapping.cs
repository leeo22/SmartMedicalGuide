using SmartMedicalGuide.Core.Features.Patients.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Patients
{
    public partial class PatientProfile
    {
        public void GetPatientListResponseMapping()
        {
            CreateMap<Patient, GetPatientListResponse>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.User != null ? src.User.FullName : null))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User != null ? src.User.Email : null))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User != null ? src.User.PhoneNumber : null));
        }
    }
}