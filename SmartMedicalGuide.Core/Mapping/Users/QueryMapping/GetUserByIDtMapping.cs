using SmartMedicalGuide.Core.Features.Users.Queries.Results;
using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserByIDtMapping()
        {
            CreateMap<User, GetSingleUserResponse>();
            //.ForMember(dest => dest.RoleName, opt => opt
            //.MapFrom(src => src.Role.RoleName));
        }
    }
}

