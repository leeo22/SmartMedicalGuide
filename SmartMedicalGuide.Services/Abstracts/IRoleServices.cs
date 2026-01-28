using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IRoleServices
    {
        public Task<List<Role>> GetAllRolesAsync();
        public Task<string> AddAsync(Role role);
        public Task<Role> GetRoleByIdAsync(int Id);

    }
}
