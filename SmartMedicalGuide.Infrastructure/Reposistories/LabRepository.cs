using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class LabRepository : GenericRepositoryAsync<Lab>, ILabRepository
    {
        #region Fields
        private readonly DbSet<Lab> _lab;
        #endregion
        #region Constructors
        public LabRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _lab = dbContext.Set<Lab>();
        }
        #endregion

        #region Handels Functions
        public async Task<List<Lab>> GetLabsListAsync()
        {
            return await _lab.Include(d => d.User)
                                //.ThenInclude(u => u.Role)
                                .ToListAsync();
        }
        #endregion
    }
}
