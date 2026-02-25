using SmartMedicalGuide.Core.Features.Clinics.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Clinics
{
    public partial class ClinicProfile
    {
        public void GetClinicByIDMapping()
        {
            CreateMap<Clinic, GetSingleClinicResponse>()
                                            .ForMember(dest => dest.RoleName, opt => opt
                                            .MapFrom(src => src.User.Role.RoleName))
                                            .ForMember(dest => dest.UserName, opt => opt
                                            .MapFrom(src => src.User.FullName));
        }
    }
}
