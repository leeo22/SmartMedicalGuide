using SmartMedicalGuide.Core.Features.Labs.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Labs
{
    public partial class LabProfile
    {
        public void GetLabListMapping()
        {
            CreateMap<Lab, GetLabListRespones>()
                .ForMember(dest => dest.RoleName, opt => opt
                //.MapFrom(src => src.User.Role.RoleName))
                //.ForMember(dest => dest.UserName, opt => opt
                .MapFrom(src => src.User.FullName));
        }
    }
}
