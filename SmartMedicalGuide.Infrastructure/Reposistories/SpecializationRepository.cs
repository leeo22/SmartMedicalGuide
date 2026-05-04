using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class SpecializationRepository : GenericRepositoryAsync<Specialization>, ISpecializationRepository
    {
        #region Fields
        private readonly DbSet<Specialization> _specializations;
        #endregion

        #region Constructors
        public SpecializationRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _specializations = dbContext.Set<Specialization>();
        }
        #endregion

        #region Basic Handlers
        public async Task<Specialization?> GetSpecializationByIdWithIncludesAsync(int id)
        {
            return await _specializations
                .Include(x => x.Doctors)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.SpecializationId == id);
        }

        public async Task<List<Specialization>> GetAllSpecializationsWithIncludesAsync()
        {
            return await _specializations
                .Include(x => x.Doctors)
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<Specialization?> GetByNameAsync(string name)
        {
            return await _specializations
                .Where(x => x.Name == name && !x.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Specialization>> SearchSpecializationsAsync(string keyword)
        {
            return await _specializations
                .Where(x => (x.Name.Contains(keyword) ||
                            (x.Description != null && x.Description.Contains(keyword))) &&
                            !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<int> GetDoctorsCountBySpecializationAsync(int specializationId)
        {
            var specialization = await _specializations
                .Include(x => x.Doctors)
                .Where(x => x.SpecializationId == specializationId && !x.IsDeleted)
                .FirstOrDefaultAsync();

            return specialization?.Doctors?.Count(d => !d.IsDeleted) ?? 0;
        }

        public async Task<Specialization?> GetSpecializationWithDetailsAsync(int id)
        {
            return await _specializations
                .Include(x => x.Doctors)
                    .ThenInclude(d => d.User)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.SpecializationId == id);
        }
        #endregion
    }
}