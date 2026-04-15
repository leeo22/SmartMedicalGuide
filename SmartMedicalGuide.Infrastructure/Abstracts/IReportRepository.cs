using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IReportRepository : IGenericRepositoryAsync<Report>
    {
        public Task<List<Report>> GetAllListAsync();
    }
}
