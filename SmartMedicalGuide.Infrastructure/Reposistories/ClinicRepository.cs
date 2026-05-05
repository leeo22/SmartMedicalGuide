using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class ClinicRepository : GenericRepositoryAsync<Clinic>, IClinicRepository
    {
        #region Fields
        private readonly DbSet<Clinic> _clinics;
        #endregion

        #region Constructors
        public ClinicRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _clinics = dbContext.Set<Clinic>();
        }
        #endregion

        #region Basic Handlers
        public async Task<Clinic?> GetClinicByIdWithIncludesAsync(int id)
        {
            return await _clinics
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => !x.IsDeleted && x.IsActive)
                .FirstOrDefaultAsync(x => x.ClinicId == id);
        }

        public async Task<List<Clinic>> GetAllClinicsWithIncludesAsync()
        {
            return await _clinics
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.ClinicName)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<List<Clinic>> GetByDoctorIdAsync(int doctorId)
        {
            return await _clinics
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.DoctorId == doctorId && !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.ClinicName)
                .ToListAsync();
        }

        public async Task<List<Clinic>> GetByLocationAsync(string location)
        {
            return await _clinics
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.Location.Contains(location) && !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.ClinicName)
                .ToListAsync();
        }

        public async Task<List<Clinic>> SearchClinicsAsync(string keyword)
        {
            return await _clinics
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => (x.ClinicName.Contains(keyword) ||
                            x.Location.Contains(keyword) ||
                            (x.Doctor != null && x.Doctor.User.FullName.Contains(keyword)) ||
                            x.Description.Contains(keyword)) &&
                            !x.IsDeleted && x.IsActive)
                .OrderBy(x => x.ClinicName)
                .ToListAsync();
        }

        public async Task<Clinic?> GetClinicWithDoctorAsync(int id)
        {
            return await _clinics
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.Specialization)
                .Where(x => !x.IsDeleted && x.IsActive)
                .FirstOrDefaultAsync(x => x.ClinicId == id);
        }

        public async Task<List<Clinic>> GetActiveClinicsAsync()
        {
            return await _clinics
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Where(x => x.IsActive && !x.IsDeleted)
                .OrderBy(x => x.ClinicName)
                .ToListAsync();
        }
        #endregion
    }
}