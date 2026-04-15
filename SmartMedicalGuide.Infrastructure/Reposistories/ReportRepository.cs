using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class ReportRepository : GenericRepositoryAsync<Report>, IReportRepository
    {
        #region Fields
        private readonly DbSet<Report> _report;
        #endregion
        #region Constructors
        public ReportRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _report = dbContext.Set<Report>();
        }
        #endregion
        public async Task<List<Report>> GetAllListAsync()
        {
            return await _report.ToListAsync();
        }


    }
}
