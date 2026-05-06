using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IReviewRepository : IGenericRepositoryAsync<Review>
    {
        Task<Review?> GetReviewByIdWithIncludesAsync(int id);
        Task<List<Review>> GetAllReviewsWithIncludesAsync();
        Task<List<Review>> GetByTargetAsync(string targetType, int targetId);
        Task<List<Review>> GetByPatientIdAsync(int patientId);
        Task<double> GetAverageRatingAsync(string targetType, int targetId);
        Task<object> GetRatingDistributionAsync(string targetType, int targetId);
        Task<List<Review>> GetRecentReviewsAsync(string targetType, int targetId, int page, int pageSize);
        Task<bool> CheckPatientReviewedAsync(int patientId, string targetType, int targetId);
        Task<List<Review>> GetReviewsByRatingAsync(string targetType, int targetId, int minRating, int maxRating);
        Task<int> GetReviewsCountByTargetAsync(string targetType, int targetId);
    }
}