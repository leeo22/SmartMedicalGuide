using SmartMedicalGuide.Data.Entities;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
=======
>>>>>>> 5544136e3ebc971ee1f59abf8801ca62912e2f8d

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
