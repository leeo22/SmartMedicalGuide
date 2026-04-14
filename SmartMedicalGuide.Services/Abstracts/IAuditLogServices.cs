using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IAuditLogServices
    {
        public Task<List<AuditLog>> GetAuditLogsListAsync();
        public Task<string> AddAsync(AuditLog auditLog);
        public Task<AuditLog> GetAuditLogByIDAsync(int id);
        public Task<string> EditAsync(AuditLog auditLog);
        public Task<string> DeleteAsync(AuditLog auditLog);
    }
}
