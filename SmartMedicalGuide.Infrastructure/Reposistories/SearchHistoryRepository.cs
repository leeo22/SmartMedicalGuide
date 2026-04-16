using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class SearchHistoryRepository : GenericRepositoryAsync<SearchHistory>, ISearchHistoryRepository
    {
        #region Fields
        private readonly DbSet<SearchHistory> _searchHistory;
        #endregion

        #region Constructors
        public SearchHistoryRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _searchHistory = dBContext.Set<SearchHistory>();

        }

        #endregion

        #region Handels Functions

        #endregion

    }
}
