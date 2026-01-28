using SmartMedicalGuide.Core.Features.Roles.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Roles
{
    public partial class RoleProfile
    {
        public void GetRoleByIDMapping()
        {
            CreateMap<Role, GetSingleRoleResponse>();
        }
    }
}
