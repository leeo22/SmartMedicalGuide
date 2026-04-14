using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IAuditLogRepository : IGenericRepositoryAsync<AuditLog>
    {
        public Task<List<AuditLog>> GetAuditLogsListAsync();
    }
}
