using SmartMedicalGuide.Core.Features.Patients.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Patients
{
    public partial class PatientProfile
    {
        public void GetPatientListMapping()
        {
            CreateMap<Patient, GetPatientListResponse>()
                                                    .ForMember(dest => dest.RoleName, opt => opt
                                                    //.MapFrom(src => src.User.Role.RoleName))
                                                    //.ForMember(dest => dest.UserName, opt => opt
                                                    .MapFrom(src => src.User.FullName));
        }
    }
}
