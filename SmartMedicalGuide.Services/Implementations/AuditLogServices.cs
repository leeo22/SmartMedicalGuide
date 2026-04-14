using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class AuditLogServices : IAuditLogServices
    {
        #region Fields
        public readonly IAuditLogRepository _auditLogRepository;

        #endregion
        #region Constructors
        public AuditLogServices(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }


        #endregion
        #region Handels Functions
        public async Task<List<AuditLog>> GetAuditLogsListAsync()
        {
            return await _auditLogRepository.GetAuditLogsListAsync();
        }
        public async Task<string> AddAsync(AuditLog auditLog)
        {
            await _auditLogRepository.AddAsync(auditLog);
            return "Success";
        }

        public async Task<string> DeleteAsync(AuditLog auditLog)
        {
            var trans = _auditLogRepository.BeginTransaction();
            try
            {
                await _auditLogRepository.DeleteAsync(auditLog);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }
        }
        public async Task<string> EditAsync(AuditLog auditLog)
        {
            await _auditLogRepository.UpdateAsync(auditLog);
            return "Success";
        }
        public async Task<AuditLog?> GetAuditLogByIDAsync(int id)
        {
            var auditLog = _auditLogRepository.GetByIdAsync()
                                      .Where(x => x.LogId.Equals(id))
                                      .FirstOrDefault();
            return auditLog;
        }
        #endregion


    }
}
