using SmartMedicalGuide.Core.Features.Roles.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Roles
{
    public partial class RoleProfile
    {
        public void AddRoleCommandMapping()
        {
            CreateMap<AddRoleCommand, Role>();
        }
    }
}
