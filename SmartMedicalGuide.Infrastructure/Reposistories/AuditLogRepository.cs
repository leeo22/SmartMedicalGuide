using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class AuditLogRepository : GenericRepositoryAsync<AuditLog>, IAuditLogRepository
    {
        #region Fields
        private readonly DbSet<AuditLog> _auditLog;
        #endregion
        #region Constructors
        public AuditLogRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _auditLog = dbContext.Set<AuditLog>();
        }
        #endregion
        #region Handels Functions


        public async Task<List<AuditLog>> GetAuditLogsListAsync()
        {
            return await _auditLog.ToListAsync();
        }
        #endregion

    }
}
