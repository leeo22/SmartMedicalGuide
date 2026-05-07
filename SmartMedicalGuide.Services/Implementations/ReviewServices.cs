using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class ReviewServices : IReviewServices
    {
        #region Fields
        private readonly IReviewRepository _reviewRepository;
        #endregion

        #region Constructors
        public ReviewServices(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<Review>> GetListAsync()
        {
            try
            {
                return await _reviewRepository.GetAllReviewsWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting reviews list: {ex.Message}", ex);
            }
        }

        public async Task<Review?> GetByIDAsync(int id)
        {
            try
            {
                return await _reviewRepository.GetReviewByIdWithIncludesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting review by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(Review review)
        {
            try
            {
                var alreadyReviewed = await _reviewRepository.CheckPatientReviewedAsync(
                    review.PatientId, review.TargetType, review.TargetId);

                if (alreadyReviewed)
                    return "Patient has already reviewed this target";

                review.CreatedAt = DateTime.UtcNow;
                review.IsDeleted = false;
                review.IsEdited = false;
                review.LastUpdatedAt = null;

                await _reviewRepository.AddAsync(review);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add review: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(Review review)
        {
            try
            {
                var existing = await _reviewRepository.GetTableAsTracking()
                    .FirstOrDefaultAsync(x => x.ReviewId == review.ReviewId && !x.IsDeleted);

                if (existing == null)
                    return "Review not found";

                existing.Rating = review.Rating;
                existing.Comment = review.Comment;
                existing.IsEdited = true;
                existing.LastUpdatedAt = DateTime.UtcNow;

                await _reviewRepository.UpdateAsync(existing);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit review: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(Review review)
        {
            try
            {
                review.IsDeleted = true;
                await _reviewRepository.UpdateAsync(review);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete review: {ex.Message}";
            }
        }
        #endregion

        #region Additional Important Functions
        public async Task<List<Review>> GetByTargetAsync(string targetType, int targetId)
        {
            try
            {
                return await _reviewRepository.GetByTargetAsync(targetType, targetId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting reviews for target {targetType}/{targetId}: {ex.Message}", ex);
            }
        }

        public async Task<List<Review>> GetByPatientIdAsync(int patientId)
        {
            try
            {
                return await _reviewRepository.GetByPatientIdAsync(patientId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting reviews for patient {patientId}: {ex.Message}", ex);
            }
        }

        public async Task<double> GetAverageRatingAsync(string targetType, int targetId)
        {
            try
            {
                return await _reviewRepository.GetAverageRatingAsync(targetType, targetId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting average rating for {targetType}/{targetId}: {ex.Message}", ex);
            }
        }

        public async Task<object> GetRatingDistributionAsync(string targetType, int targetId)
        {
            try
            {
                return await _reviewRepository.GetRatingDistributionAsync(targetType, targetId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting rating distribution for {targetType}/{targetId}: {ex.Message}", ex);
            }
        }

        public async Task<List<Review>> GetRecentReviewsAsync(string targetType, int targetId, int page, int pageSize)
        {
            try
            {
                return await _reviewRepository.GetRecentReviewsAsync(targetType, targetId, page, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting recent reviews: {ex.Message}", ex);
            }
        }

        public async Task<bool> CheckPatientReviewedAsync(int patientId, string targetType, int targetId)
        {
            try
            {
                return await _reviewRepository.CheckPatientReviewedAsync(patientId, targetType, targetId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking patient review: {ex.Message}", ex);
            }
        }

        public async Task<object> GetReviewStatisticsAsync()
        {
            try
            {
                var reviews = await _reviewRepository.GetTableAsTracking()
                    .Where(x => !x.IsDeleted)
                    .ToListAsync();

                return new
                {
                    TotalReviews = reviews.Count,
                    AverageRating = reviews.Any() ? reviews.Average(x => x.Rating) : 0,
                    ByTargetType = reviews.GroupBy(x => x.TargetType)
                        .Select(g => new { TargetType = g.Key, Count = g.Count(), AverageRating = g.Average(x => x.Rating) }),
                    ByRating = reviews.GroupBy(x => x.Rating)
                        .Select(g => new { Rating = g.Key, Count = g.Count() })
                        .OrderByDescending(x => x.Rating),
                    EditedReviews = reviews.Count(x => x.IsEdited)
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting review statistics: {ex.Message}", ex);
            }
        }
        #endregion
    }
}