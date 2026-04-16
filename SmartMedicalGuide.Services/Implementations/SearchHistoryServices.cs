using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

namespace SmartMedicalGuide.Services.Abstracts
{
    public class SearchHistoryServices : ISearchHistoryServices
    {
        #region Fields
        private readonly ISearchHistoryRepository _searchHistoryRepository;
        #endregion

        #region Constructors
        public SearchHistoryServices(ISearchHistoryRepository searchHistoryRepository)
        {
            _searchHistoryRepository = searchHistoryRepository;
        }
        #endregion

        #region Handlers Functions
        public async Task<string> AddAsync(SearchHistory searchHistory)
        {
            await _searchHistoryRepository.AddAsync(searchHistory);
            return "Success";
        }

        public async Task<string> DeleteAsync(SearchHistory searchHistory)
        {
            var trans = _searchHistoryRepository.BeginTransaction();
            try
            {
                await _searchHistoryRepository.DeleteAsync(searchHistory);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> DeleteAllForUserAsync(int userId)
        {
            var trans = _searchHistoryRepository.BeginTransaction();
            try
            {
                var histories = await _searchHistoryRepository.GetTableAsTracking()
                    .Where(x => x.UserId == userId)
                    .ToListAsync();

                foreach (var history in histories)
                {
                    await _searchHistoryRepository.DeleteAsync(history);
                }

                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(SearchHistory searchHistory)
        {
            await _searchHistoryRepository.UpdateAsync(searchHistory);
            return "Success";
        }

        public async Task<SearchHistory> GetByIDAsync(int id)
        {
            var result = _searchHistoryRepository.GetByIdAsync()
                                            .Where(x => x.SearchId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<List<SearchHistory>> GetByUserIdAsync(int userId)
        {
            return await _searchHistoryRepository.GetTableAsTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<SearchHistory>> GetListAsync()
        {
            return await _searchHistoryRepository.GetTableAsTracking().ToListAsync();
        }

        public async Task<List<SearchHistory>> GetRecentByUserIdAsync(int userId, int count)
        {
            return await _searchHistoryRepository.GetTableAsTracking()
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.CreatedAt)
                .Take(count)
                .ToListAsync();
        }
        #endregion
    }
}