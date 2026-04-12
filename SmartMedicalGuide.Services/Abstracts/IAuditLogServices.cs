using SmartMedicalGuide.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
