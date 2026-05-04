using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class DoctorRepository : GenericRepositoryAsync<Doctor>, IDoctorRepository
    {
        #region Fields
        private readonly DbSet<Doctor> _doctors;
        #endregion

        #region Constructors
        public DoctorRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _doctors = dbContext.Set<Doctor>();
        }
        #endregion

        #region Basic Handlers
        public async Task<Doctor?> GetDoctorByIdWithIncludesAsync(int id)
        {
            return await _doctors
                .Include(x => x.User)
                .Include(x => x.Specialization)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.DoctorId == id);
        }

        public async Task<List<Doctor>> GetAllDoctorsWithIncludesAsync()
        {
            return await _doctors
                .Include(x => x.User)
                .Include(x => x.Specialization)
                .Where(x => !x.IsDeleted)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<Doctor?> GetByUserIdAsync(int userId)
        {
            return await _doctors
                .Include(x => x.User)
                .Include(x => x.Specialization)
                .Include(x => x.Reviews)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<List<Doctor>> GetBySpecializationIdAsync(int specializationId)
        {
            return await _doctors
                .Include(x => x.User)
                .Include(x => x.Specialization)
                .Where(x => x.SpecializationId == specializationId && !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<List<Doctor>> GetVerifiedDoctorsAsync()
        {
            return await _doctors
                .Include(x => x.User)
                .Include(x => x.Specialization)
                .Where(x => x.VerificationStatus == "Verified" && !x.IsDeleted && x.IsAvailableForBooking)
                .ToListAsync();
        }

        public async Task<List<Doctor>> SearchDoctorsAsync(string keyword)
        {
            return await _doctors
                .Include(x => x.User)
                .Include(x => x.Specialization)
                .Where(x => !x.IsDeleted &&
                    (x.User.FullName.Contains(keyword) ||
                     x.Specialization.Name.Contains(keyword) ||
                     x.Bio.Contains(keyword)))
                .ToListAsync();
        }

        public async Task<List<Doctor>> GetTopRatedDoctorsAsync(int limit)
        {
            return await _doctors
                .Include(x => x.User)
                .Include(x => x.Specialization)
                .Include(x => x.Reviews)
                .Where(x => !x.IsDeleted && x.Reviews.Any())
                .OrderByDescending(x => x.Reviews.Average(r => r.Rating))
                .Take(limit)
                .ToListAsync();
        }

        public async Task<List<Doctor>> GetDoctorsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _doctors
                .Include(x => x.User)
                .Include(x => x.Specialization)
                .Where(x => x.ConsultationPrice >= minPrice && x.ConsultationPrice <= maxPrice && !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<Doctor?> GetDoctorWithDetailsAsync(int id)
        {
            return await _doctors
                .Include(x => x.User)
                .Include(x => x.Specialization)
                .Include(x => x.Clinics)
                .Include(x => x.DoctorSchedules)
                .Include(x => x.DoctorCapacitySettings)
                .Include(x => x.Reviews)
                    .ThenInclude(r => r.Patient)
                        .ThenInclude(p => p.User)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.DoctorId == id);
        }

        public async Task<List<Doctor>> GetAvailableForBookingDoctorsAsync()
        {
            return await _doctors
                .Include(x => x.User)
                .Include(x => x.Specialization)
                .Where(x => x.IsAvailableForBooking && !x.IsDeleted && x.VerificationStatus == "Verified")
                .ToListAsync();
        }
        #endregion
    }
}