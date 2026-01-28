using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class RoleServices : IRoleServices
    {
        #region Fields
        private readonly IRoleRepository _roleRepository;
        #endregion
        #region Constructors
        public RoleServices(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;

        }


        #endregion
        #region Handels Functions
        public async Task<string> AddAsync(Role role)
        {
            await _roleRepository.AddAsync(role);
            return "Success";
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int Id)
        {
            var role = _roleRepository.GetByIdAsync().Where(x => x.RoleId.Equals(Id)).FirstOrDefault();

            return role;
        }


        #endregion

    }
}
