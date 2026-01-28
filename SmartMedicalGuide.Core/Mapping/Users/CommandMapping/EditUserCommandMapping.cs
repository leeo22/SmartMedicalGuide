using SmartMedicalGuide.Core.Features.Users.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void EditUserCommandMapping()
        {
            CreateMap<EditUserCommand, User>()
                        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                       .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                       ;
        }

    }
}
