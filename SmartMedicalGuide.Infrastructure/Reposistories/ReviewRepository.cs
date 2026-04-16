using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class ReviewRepository : GenericRepositoryAsync<Review>, IReviewRepository
    {
        #region Fields
        private readonly DbSet<Review> _review;
        #endregion

        #region Constructors
        public ReviewRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _review = dBContext.Set<Review>();

        }

        #endregion

        #region Handels Functions

        #endregion

    }
}
