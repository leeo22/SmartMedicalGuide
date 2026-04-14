//using Microsoft.EntityFrameworkCore;
//using SmartMedicalGuide.Data.Entities;
//using SmartMedicalGuide.Infrastructure.Abstracts;
//using SmartMedicalGuide.Infrastructure.Context;
//using SmartMedicalGuide.Infrastructure.InfrastuctureBases;
<<<<<<< HEAD
//<<<<<<< HEAD
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//=======
//>>>>>>> 5544136e3ebc971ee1f59abf8801ca62912e2f8d

//namespace SmartMedicalGuide.Infrastructure.Reposistories
//{
//    public class AuditLogRepository : GenericRepositoryAsync<AuditLog>, IAuditLogRepository
//    {
//        #region Fields
//        private readonly DbSet<AuditLog> _auditLog;
//        #endregion
//        #region Constructors
//        public AuditLogRepository(MedicalGuideDbContext dbContext) : base(dbContext)
//        {
//            _auditLog = dbContext.Set<AuditLog>();
//        }
//        #endregion
//<<<<<<< HEAD

//        #region Handels Functions
//        public async Task<List<AuditLog>> GetAuditLogsListAsync()
//        {
//            return await _auditLog.Include(d => d.User)
//                                .ThenInclude(u => u.Role)
//                                .ToListAsync();
//        }
//        #endregion
//=======
//        #region Handels Functions


//        public async Task<List<AuditLog>> GetAuditLogsListAsync()
//        {
//            return await _auditLog.ToListAsync();
//        }
//        #endregion

//>>>>>>> 5544136e3ebc971ee1f59abf8801ca62912e2f8d
=======



//namespace SmartMedicalGuide.Infrastructure.Reposistories
//{
//    public class AuditLogRepository : GenericRepositoryAsync<AuditLog>, IAuditLogRepository
//    {
//        #region Fields
//        private readonly DbSet<AuditLog> _auditLog;
//        #endregion
//        #region Constructors
//        public AuditLogRepository(MedicalGuideDbContext dbContext) : base(dbContext)
//        {
//            _auditLog = dbContext.Set<AuditLog>();
//        }
//        #endregion


//        #region Handels Functions
//        public async Task<List<AuditLog>> GetAuditLogsListAsync()
//        {
//            return await _auditLog.Include(d => d.User)
//                                .ThenInclude(u => u.Role)
//                                .ToListAsync();
//        }
//        #endregion

//        #region Handels Functions


//        public async Task<List<AuditLog>> GetAuditLogsListAsync()
//        {
//            return await _auditLog.ToListAsync();
//        }
//        #endregion


>>>>>>> 8b264d17e25260ca316219f520115ed46d6b195f
//    }
//}
