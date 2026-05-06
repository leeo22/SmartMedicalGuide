using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class LabServiceRepository : GenericRepositoryAsync<LabService>, ILabServiceRepository
    {
        #region Fields
        private readonly DbSet<LabService> _services;
        #endregion

        #region Constructors
        public LabServiceRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _services = dbContext.Set<LabService>();
        }
        #endregion

        #region Basic Handlers
        public async Task<LabService?> GetServiceByIdWithIncludesAsync(int id)
        {
            return await _services
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => !x.IsDeleted && x.IsActive)
                .FirstOrDefaultAsync(x => x.ServiceId == id);
        }

        public async Task<List<LabService>> GetAllServicesWithIncludesAsync()
        {
            return await _services
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.ServiceName)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<List<LabService>> GetByLabIdAsync(int labId)
        {
            return await _services
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => x.LabId == labId && !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.ServiceName)
                .ToListAsync();
        }

        public async Task<List<LabService>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            decimal? finalPrice = null;

            var services = await _services
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => !x.IsDeleted && x.IsActive)
                .ToListAsync();

            var filteredServices = services.Where(x =>
            {
                finalPrice = x.DiscountPercentage.HasValue && x.DiscountPercentage.Value > 0
                    ? x.Price - (x.Price * (x.DiscountPercentage.Value / 100))
                    : x.Price;

                return finalPrice >= minPrice && finalPrice <= maxPrice;
            }).ToList();

            return filteredServices;
        }

        public async Task<List<LabService>> SearchServicesAsync(string keyword)
        {
            return await _services
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => (x.ServiceName.Contains(keyword) ||
                            x.Description.Contains(keyword) ||
                            x.Category.Contains(keyword)) &&
                            !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.ServiceName)
                .ToListAsync();
        }

        public async Task<List<LabService>> GetActiveServicesAsync()
        {
            return await _services
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => x.IsActive && !x.IsDeleted)
                .OrderBy(x => x.ServiceName)
                .ToListAsync();
        }

        public async Task<List<LabService>> GetLabServicesWithLabAsync(int labId)
        {
            return await _services
                .Include(x => x.Lab)
                    .ThenInclude(l => l.User)
                .Where(x => x.LabId == labId && !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.ServiceName)
                .ToListAsync();
        }
        #endregion
    }
}