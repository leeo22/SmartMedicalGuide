using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class LabRepository : GenericRepositoryAsync<Lab>, ILabRepository
    {
        #region Fields
        private readonly DbSet<Lab> _labs;
        #endregion

        #region Constructors
        public LabRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _labs = dbContext.Set<Lab>();
        }
        #endregion

        #region Basic Handlers
        public async Task<Lab?> GetLabByIdWithIncludesAsync(int id)
        {
            return await _labs
                .Include(x => x.User)
                .Include(x => x.LabServices)
                .Where(x => !x.IsDeleted && x.IsActive)
                .FirstOrDefaultAsync(x => x.LabId == id);
        }

        public async Task<List<Lab>> GetAllLabsWithIncludesAsync()
        {
            return await _labs
                .Include(x => x.User)
                .Include(x => x.LabServices)
                .Where(x => !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.CenterName)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<Lab?> GetByUserIdAsync(int userId)
        {
            return await _labs
                .Include(x => x.User)
                .Include(x => x.LabServices)
                .Where(x => !x.IsDeleted && x.IsActive)
                .FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<List<Lab>> GetByLocationAsync(string location)
        {
            return await _labs
                .Include(x => x.User)
                .Include(x => x.LabServices)
                .Where(x => x.Location.Contains(location) && !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.CenterName)
                .ToListAsync();
        }

        public async Task<List<Lab>> GetVerifiedLabsAsync()
        {
            return await _labs
                .Include(x => x.User)
                .Include(x => x.LabServices)
                .Where(x => x.VerificationStatus == "Verified" && !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.CenterName)
                .ToListAsync();
        }

        public async Task<List<Lab>> SearchLabsAsync(string keyword)
        {
            return await _labs
                .Include(x => x.User)
                .Include(x => x.LabServices)
                .Where(x => (x.CenterName.Contains(keyword) ||
                            x.Location.Contains(keyword) ||
                            x.CenterType.Contains(keyword) ||
                            x.Description.Contains(keyword)) &&
                            !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.CenterName)
                .ToListAsync();
        }

        public async Task<Lab?> GetLabWithServicesAsync(int id)
        {
            return await _labs
                .Include(x => x.User)
                .Include(x => x.LabServices)
                .Include(x => x.LabAppointments)
                .Where(x => !x.IsDeleted && x.IsActive)
                .FirstOrDefaultAsync(x => x.LabId == id);
        }

        public async Task<List<Lab>> GetActiveLabsAsync()
        {
            return await _labs
                .Include(x => x.User)
                .Include(x => x.LabServices)
                .Where(x => x.IsActive && !x.IsDeleted)
                .OrderBy(x => x.CenterName)
                .ToListAsync();
        }

        public async Task<List<Lab>> GetLabsByServiceIdAsync(int serviceId)
        {
            return await _labs
                .Include(x => x.User)
                .Include(x => x.LabServices)
                .Where(x => x.LabServices.Any(s => s.ServiceId == serviceId) && !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.CenterName)
                .ToListAsync();
        }
        #endregion
    }
}