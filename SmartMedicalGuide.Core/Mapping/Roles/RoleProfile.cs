using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Roles
{
    public partial class RoleProfile : Profile
    {
        public RoleProfile()
        {
            AddRoleCommandMapping();
            GetRoleByIDMapping();
            GetAllRoleMapping();

        }
    }
}
