using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface ISearchHistoryServices
    {
        public Task<List<SearchHistory>> GetListAsync();
        public Task<SearchHistory> GetByIDAsync(int id);
        public Task<string> AddAsync(SearchHistory searchHistory);
        public Task<string> EditAsync(SearchHistory searchHistory);
        public Task<string> DeleteAsync(SearchHistory searchHistory);
        public Task<string> DeleteAllForUserAsync(int userId);
        public Task<List<SearchHistory>> GetByUserIdAsync(int userId);
        public Task<List<SearchHistory>> GetRecentByUserIdAsync(int userId, int count);
    }
}