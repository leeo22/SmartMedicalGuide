using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class FavoriteRepository : GenericRepositoryAsync<Favorite>, IFavoriteRepository
    {
        #region Fields
        private readonly DbSet<Favorite> _favorite;
        #endregion
        #region Constructors
        public FavoriteRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _favorite = dbContext.Set<Favorite>();
        }


        #endregion
        #region Handels Functions
        public async Task<List<Favorite>> GetFavoritesListAsync()
        {
            return await _favorite.ToListAsync();
        }
        #endregion

    }
}
