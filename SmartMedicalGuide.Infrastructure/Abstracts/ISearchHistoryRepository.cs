using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface ISearchHistoryRepository : IGenericRepositoryAsync<SearchHistory>
    {
        //public Task<List<SearchHistory>> GetSearchHistoriesListAsync();
    }
}
