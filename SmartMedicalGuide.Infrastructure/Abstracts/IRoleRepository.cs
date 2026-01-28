using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IRoleRepository : IGenericRepositoryAsync<Role>
    {
        public Task<List<Role>> GetAllRolesAsync();
    }
}
