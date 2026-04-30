using SmartMedicalGuide.Core.Features.Users.Queries.Results;
using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserByIDtMapping()
        {
            CreateMap<User, GetSingleUserResponse>().ForMember(dest => dest.FullName, opt => opt.MapFrom(srs => srs.FullName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(srs => srs.Email));

        }
    }
}

