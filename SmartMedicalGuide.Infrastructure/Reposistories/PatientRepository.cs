using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class PatientRepository : GenericRepositoryAsync<Patient>, IPatientRepository
    {
        #region Fields
        private readonly DbSet<Patient> _patients;
        #endregion

        #region Constructors
        public PatientRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _patients = dbContext.Set<Patient>();
        }
        #endregion

        #region Basic Handlers
        public async Task<Patient?> GetPatientByIdWithIncludesAsync(int id)
        {
            return await _patients
                .Include(x => x.User)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.PatientId == id);
        }

        public async Task<List<Patient>> GetAllPatientsWithIncludesAsync()
        {
            return await _patients
                .Include(x => x.User)
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<Patient?> GetByUserIdAsync(int userId)
        {
            return await _patients
                .Include(x => x.User)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<List<Patient>> SearchPatientsAsync(string keyword)
        {
            return await _patients
                .Include(x => x.User)
                .Where(x => !x.IsDeleted &&
                    (x.User.FullName.Contains(keyword) ||
                     x.User.Email.Contains(keyword) ||
                     x.User.PhoneNumber.Contains(keyword) ||
                     x.Address.Contains(keyword)))
                .ToListAsync();
        }
        #endregion
    }
}