using SmartMedicalGuide.Core.Features.Users.Commands.Models;
using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Core.Mapping.Users
{
    public partial class UserProfile
    {
        public void EditUserCommandMapping()
        {
            CreateMap<EditUserCommand, User>().ForMember(dest => dest.FullName, opt => opt.MapFrom(srs => srs.FullName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(srs => srs.Email));
        }

    }
}
