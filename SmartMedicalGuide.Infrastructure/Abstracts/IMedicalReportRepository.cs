using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IMedicalReportRepository : IGenericRepositoryAsync<MedicalReport>
    {
        //public Task<List<MedicalReport>> GetMedicalReportsListAsync();
    }
}
