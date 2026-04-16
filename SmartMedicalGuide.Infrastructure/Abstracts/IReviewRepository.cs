using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IReviewRepository : IGenericRepositoryAsync<Review>
    {
        //public Task<List<Review>> GetReviewsListAsync();
    }
}
