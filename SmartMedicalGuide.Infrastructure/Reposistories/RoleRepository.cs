using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class RoleRepository : GenericRepositoryAsync<Role>, IRoleRepository
    {
        #region Fields
        private readonly DbSet<Role> _role;
        #endregion
        #region Constructors
        public RoleRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _role = dbContext.Set<Role>();
        }


        #endregion
        #region Handels Functions
        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _role.ToListAsync();
        }
        #endregion

    }
}
