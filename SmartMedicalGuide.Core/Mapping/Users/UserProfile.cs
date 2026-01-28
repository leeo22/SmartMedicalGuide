using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserCommandMapping();
            GetUserByIDtMapping();
            GetUserListMapping();
            EditUserCommandMapping();

        }
    }
}
