using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IReviewServices
    {
        public Task<List<Review>> GetListAsync();
        public Task<Review> GetByIDAsync(int id);
        public Task<string> AddAsync(Review review);
        public Task<string> EditAsync(Review review);
        public Task<string> DeleteAsync(Review review);
        public Task<List<Review>> GetByPatientIdAsync(int patientId);
        public Task<List<Review>> GetByTargetAsync(string targetType, int targetId);
        public Task<double> GetAverageRatingForTargetAsync(string targetType, int targetId);
    }
}