using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IAuditLogRepository : IGenericRepositoryAsync<AuditLog>
    {
        public Task<List<AuditLog>> GetAuditLogsListAsync();
    }
}
