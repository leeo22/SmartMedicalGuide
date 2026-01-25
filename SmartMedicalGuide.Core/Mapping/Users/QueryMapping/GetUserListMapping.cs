using SmartMedicalGuide.Core.Features.Users.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserListMapping()
        {
            CreateMap<User, GetUserListResponse>();
        }
    }
}
