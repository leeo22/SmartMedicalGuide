using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class ReviewRepository : GenericRepositoryAsync<Review>, IReviewRepository
    {
        #region Fields
        private readonly DbSet<Review> _reviews;
        #endregion

        #region Constructors
        public ReviewRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _reviews = dbContext.Set<Review>();
        }
        #endregion

        #region Basic Handlers
        public async Task<Review?> GetReviewByIdWithIncludesAsync(int id)
        {
            return await _reviews
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.ReviewId == id);
        }

        public async Task<List<Review>> GetAllReviewsWithIncludesAsync()
        {
            return await _reviews
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<List<Review>> GetByTargetAsync(string targetType, int targetId)
        {
            return await _reviews
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Where(x => x.TargetType == targetType && x.TargetId == targetId && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Review>> GetByPatientIdAsync(int patientId)
        {
            return await _reviews
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Where(x => x.PatientId == patientId && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<double> GetAverageRatingAsync(string targetType, int targetId)
        {
            var ratings = await _reviews
                .Where(x => x.TargetType == targetType && x.TargetId == targetId && !x.IsDeleted)
                .Select(x => (double)x.Rating)
                .ToListAsync();

            return ratings.Any() ? ratings.Average() : 0;
        }

        public async Task<object> GetRatingDistributionAsync(string targetType, int targetId)
        {
            var distribution = await _reviews
                .Where(x => x.TargetType == targetType && x.TargetId == targetId && !x.IsDeleted)
                .GroupBy(x => x.Rating)
                .Select(g => new { Rating = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Rating)
                .ToListAsync();

            return distribution;
        }

        public async Task<List<Review>> GetRecentReviewsAsync(string targetType, int targetId, int page, int pageSize)
        {
            return await _reviews
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Where(x => x.TargetType == targetType && x.TargetId == targetId && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<bool> CheckPatientReviewedAsync(int patientId, string targetType, int targetId)
        {
            return await _reviews
                .AnyAsync(x => x.PatientId == patientId && x.TargetType == targetType && x.TargetId == targetId && !x.IsDeleted);
        }

        public async Task<List<Review>> GetReviewsByRatingAsync(string targetType, int targetId, int minRating, int maxRating)
        {
            return await _reviews
                .Include(x => x.Patient)
                    .ThenInclude(p => p.User)
                .Where(x => x.TargetType == targetType && x.TargetId == targetId
                            && x.Rating >= minRating && x.Rating <= maxRating && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<int> GetReviewsCountByTargetAsync(string targetType, int targetId)
        {
            return await _reviews
                .CountAsync(x => x.TargetType == targetType && x.TargetId == targetId && !x.IsDeleted);
        }
        #endregion
    }
}