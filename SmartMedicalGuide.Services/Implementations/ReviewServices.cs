using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

namespace SmartMedicalGuide.Services.Abstracts
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

        #region Handlers Functions
        public async Task<string> AddAsync(Review review)
        {
            await _reviewRepository.AddAsync(review);
            return "Success";
        }

        public async Task<string> DeleteAsync(Review review)
        {
            var trans = _reviewRepository.BeginTransaction();
            try
            {
                await _reviewRepository.DeleteAsync(review);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(Review review)
        {
            await _reviewRepository.UpdateAsync(review);
            return "Success";
        }

        public async Task<double> GetAverageRatingForTargetAsync(string targetType, int targetId)
        {
            var ratings = await _reviewRepository.GetTableAsTracking()
                .Where(x => x.TargetType == targetType && x.TargetId == targetId)
                .Select(x => x.Rating)
                .ToListAsync();

            if (ratings.Count == 0) return 0;
            return ratings.Average();
        }

        public async Task<Review> GetByIDAsync(int id)
        {
            var result = _reviewRepository.GetByIdAsync()
                                            .Where(x => x.ReviewId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<List<Review>> GetByPatientIdAsync(int patientId)
        {
            return await _reviewRepository.GetTableAsTracking()
                .Where(x => x.PatientId == patientId)
                .ToListAsync();
        }

        public async Task<List<Review>> GetByTargetAsync(string targetType, int targetId)
        {
            return await _reviewRepository.GetTableAsTracking()
                .Where(x => x.TargetType == targetType && x.TargetId == targetId)
                .ToListAsync();
        }

        public async Task<List<Review>> GetListAsync()
        {
            return await _reviewRepository.GetTableAsTracking().ToListAsync();
        }
        #endregion
    }
}