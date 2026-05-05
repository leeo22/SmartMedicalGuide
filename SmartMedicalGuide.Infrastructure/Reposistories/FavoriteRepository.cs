using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class FavoriteRepository : GenericRepositoryAsync<Favorite>, IFavoriteRepository
    {
        #region Fields
        private readonly DbSet<Favorite> _favorites;
        #endregion

        #region Constructors
        public FavoriteRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _favorites = dbContext.Set<Favorite>();
        }
        #endregion

        #region Basic Handlers
        public async Task<Favorite?> GetFavoriteByIdWithIncludesAsync(int id)
        {
            return await _favorites
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.Specialization)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.FavoriteId == id);
        }

        public async Task<List<Favorite>> GetAllFavoritesWithIncludesAsync()
        {
            return await _favorites
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.Specialization)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<List<Favorite>> GetByPatientIdAsync(int patientId)
        {
            return await _favorites
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.Specialization)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.Reviews)
                .Where(x => x.PatientId == patientId && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Favorite>> GetByDoctorIdAsync(int doctorId)
        {
            return await _favorites
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Where(x => x.DoctorId == doctorId && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> IsFavoriteAsync(int patientId, int doctorId)
        {
            return await _favorites
                .AnyAsync(x => x.PatientId == patientId && x.DoctorId == doctorId && !x.IsDeleted);
        }

        public async Task<List<Favorite>> GetFavoriteDoctorsWithDetailsAsync(int patientId)
        {
            return await _favorites
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.Specialization)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.Reviews)
                .Where(x => x.PatientId == patientId && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<int> GetFavoriteCountByDoctorAsync(int doctorId)
        {
            return await _favorites
                .CountAsync(x => x.DoctorId == doctorId && !x.IsDeleted);
        }

        public async Task<List<Favorite>> GetMostFavoriteDoctorsAsync(int limit)
        {
            return await _favorites
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.Specialization)
                .Where(x => !x.IsDeleted)
                .GroupBy(x => x.DoctorId)
                .Select(g => new { DoctorId = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(limit)
                .Join(_favorites, x => x.DoctorId, f => f.DoctorId, (x, f) => f)
                .Include(f => f.Doctor)
                    .ThenInclude(d => d.User)
                .Include(f => f.Doctor)
                    .ThenInclude(d => d.Specialization)
                .ToListAsync();
        }

        public async Task<bool> DeleteAllByPatientAsync(int patientId)
        {
            try
            {
                var favorites = await _favorites
                    .Where(x => x.PatientId == patientId && !x.IsDeleted)
                    .ToListAsync();

                foreach (var favorite in favorites)
                {
                    favorite.IsDeleted = true;
                }

                 _favorites.UpdateRange(favorites);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}