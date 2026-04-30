using SmartMedicalGuide.Core.Features.Authorization.Quaries.Results;
using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Core.Mapping.Roles
{
    public partial class RoleProfile
    {
        public void GetRoleByIdMapping()
        {
            CreateMap<Role, GetRoleByIdResult>();
        }
    }
}
