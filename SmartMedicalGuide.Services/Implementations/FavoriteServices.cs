using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class FavoriteServices : IFavoriteServices
    {
        #region Fields
        private readonly IFavoriteRepository _favoriteRepository;
        #endregion
        #region Constructors
        public FavoriteServices(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }


        #endregion
        #region Handels Functions


        public async Task<string> AddAsync(Favorite favorite)
        {
            await _favoriteRepository.AddAsync(favorite);
            return "Success";
        }


        public async Task<string> DeleteAsync(Favorite favorite)
        {
            var trans = _favoriteRepository.BeginTransaction();
            try
            {
                await _favoriteRepository.DeleteAsync(favorite);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }
        }

        public async Task<string> EditAsync(Favorite favorite)
        {
            await _favoriteRepository.UpdateAsync(favorite);
            return "Success";
        }

        public async Task<List<Favorite>> GetListAsync()
        {
            return await _favoriteRepository.GetFavoritesListAsync();
        }

        public async Task<Favorite> GetByIDAsync(int id)
        {
            var report = _favoriteRepository.GetByIdAsync()
                                            .Where(x => x.FavoriteId.Equals(id))
                                            .FirstOrDefault();
            return report;
        }



        #endregion
    }
}
