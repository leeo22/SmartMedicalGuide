using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IFavoriteServices
    {
        public Task<List<Favorite>> GetListAsync();
        public Task<Favorite> GetByIDAsync(int id);
        public Task<string> AddAsync(Favorite favorite);
        public Task<string> EditAsync(Favorite favorite);
        public Task<string> DeleteAsync(Favorite favorite);
    }
}
