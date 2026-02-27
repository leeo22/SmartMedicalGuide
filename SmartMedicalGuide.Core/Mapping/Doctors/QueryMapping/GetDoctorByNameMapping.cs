using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Doctors
{
    public partial class DoctorProfile
    {
        public void GetDoctorByNameMapping()
        {
            CreateMap<Doctor, GetSingleDoctorResponse>()
                                            .ForMember(dest => dest.RoleName, opt => opt
                                            .MapFrom(src => src.User.Role.RoleName))
                                            .ForMember(dest => dest.UserName, opt => opt
                                            .MapFrom(src => src.User.FullName))
                                            .ForMember(dest => dest.FullName, opt => opt
                                            .MapFrom(src => src.User.FullName));
        }
    }
}