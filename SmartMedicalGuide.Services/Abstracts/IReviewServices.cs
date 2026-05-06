using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IReviewServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<Review>> GetListAsync();
        Task<Review?> GetByIDAsync(int id);
        Task<string> AddAsync(Review review);
        Task<string> EditAsync(Review review);
        Task<string> DeleteAsync(Review review);
        #endregion

        #region Additional Important Functions - 7 Functions
        Task<List<Review>> GetByTargetAsync(string targetType, int targetId);
        Task<List<Review>> GetByPatientIdAsync(int patientId);
        Task<double> GetAverageRatingAsync(string targetType, int targetId);
        Task<object> GetRatingDistributionAsync(string targetType, int targetId);
        Task<List<Review>> GetRecentReviewsAsync(string targetType, int targetId, int page, int pageSize);
        Task<bool> CheckPatientReviewedAsync(int patientId, string targetType, int targetId);
        Task<object> GetReviewStatisticsAsync();
        #endregion
    }
}