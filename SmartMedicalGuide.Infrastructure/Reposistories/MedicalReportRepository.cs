using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class MedicalReportRepository : GenericRepositoryAsync<MedicalReport>, IMedicalReportRepository
    {
        #region Fields
        private readonly DbSet<MedicalReport> _reports;
        #endregion

        #region Constructors
        public MedicalReportRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _reports = dbContext.Set<MedicalReport>();
        }
        #endregion

        #region Basic Handlers
        public async Task<MedicalReport?> GetReportByIdWithIncludesAsync(int id)
        {
            try
            {
                return await _reports
                    .Include(x => x.Patient)
                        .ThenInclude(p => p.User)
                    .Include(x => x.Doctor)
                        .ThenInclude(d => d.User)
                    .Where(x => !x.IsDeleted)
                    .FirstOrDefaultAsync(x => x.ReportId == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting report by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<List<MedicalReport>> GetAllReportsWithIncludesAsync()
        {
            try
            {
                return await _reports
                    .Include(x => x.Patient)
                        .ThenInclude(p => p.User)
                    .Include(x => x.Doctor)
                        .ThenInclude(d => d.User)
                    .Where(x => !x.IsDeleted)
                    .OrderByDescending(x => x.ReportDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting all reports: {ex.Message}", ex);
            }
        }
        #endregion

        #region Additional Handlers
        public async Task<List<MedicalReport>> GetByPatientIdAsync(int patientId)
        {
            try
            {
                return await _reports
                    .Include(x => x.Patient)
                        .ThenInclude(p => p.User)
                    .Include(x => x.Doctor)
                        .ThenInclude(d => d.User)
                    .Where(x => x.PatientId == patientId && !x.IsDeleted)
                    .OrderByDescending(x => x.ReportDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting reports for patient {patientId}: {ex.Message}", ex);
            }
        }

        public async Task<List<MedicalReport>> GetByDoctorIdAsync(int doctorId)
        {
            try
            {
                return await _reports
                    .Include(x => x.Patient)
                        .ThenInclude(p => p.User)
                    .Include(x => x.Doctor)
                        .ThenInclude(d => d.User)
                    .Where(x => x.DoctorId == doctorId && !x.IsDeleted)
                    .OrderByDescending(x => x.ReportDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting reports for doctor {doctorId}: {ex.Message}", ex);
            }
        }

        public async Task<List<MedicalReport>> GetByReportTypeAsync(string reportType)
        {
            try
            {
                return await _reports
                    .Include(x => x.Patient)
                        .ThenInclude(p => p.User)
                    .Include(x => x.Doctor)
                        .ThenInclude(d => d.User)
                    .Where(x => x.ReportType == reportType && !x.IsDeleted)
                    .OrderByDescending(x => x.ReportDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting reports by type {reportType}: {ex.Message}", ex);
            }
        }

        public async Task<List<MedicalReport>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            try
            {
                return await _reports
                    .Include(x => x.Patient)
                        .ThenInclude(p => p.User)
                    .Include(x => x.Doctor)
                        .ThenInclude(d => d.User)
                    .Where(x => x.ReportDate >= fromDate && x.ReportDate <= toDate && !x.IsDeleted)
                    .OrderBy(x => x.ReportDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting reports by date range: {ex.Message}", ex);
            }
        }

        public async Task<List<MedicalReport>> GetPatientMedicalReportsWithDetailsAsync(int patientId)
        {
            try
            {
                return await _reports
                    .Include(x => x.Patient)
                        .ThenInclude(p => p.User)
                    .Include(x => x.Doctor)
                        .ThenInclude(d => d.User)
                    .Where(x => x.PatientId == patientId && !x.IsDeleted)
                    .OrderByDescending(x => x.ReportDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting detailed reports for patient {patientId}: {ex.Message}", ex);
            }
        }

        public async Task<List<MedicalReport>> GetPatientMedicalHistoryAsync(int patientId)
        {
            try
            {
                return await _reports
                    .Include(x => x.Patient)
                        .ThenInclude(p => p.User)
                    .Include(x => x.Doctor)
                        .ThenInclude(d => d.User)
                    .Where(x => x.PatientId == patientId && !x.IsDeleted)
                    .OrderBy(x => x.ReportDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting medical history for patient {patientId}: {ex.Message}", ex);
            }
        }

        public async Task<object> GetReportStatisticsAsync()
        {
            try
            {
                var query = _reports.Where(x => !x.IsDeleted);
                var reports = await query.ToListAsync();

                return new
                {
                    TotalReports = reports.Count,
                    ByReportType = reports.GroupBy(x => x.ReportType)
                        .Select(g => new { ReportType = g.Key, Count = g.Count() }),
                    ByMonth = reports.GroupBy(x => new { x.ReportDate.Year, x.ReportDate.Month })
                        .Select(g => new { Year = g.Key.Year, Month = g.Key.Month, Count = g.Count() })
                        .OrderBy(x => x.Year)
                        .ThenBy(x => x.Month),
                    TotalFileSize = reports.Sum(x => x.FileSize ?? 0),
                    AverageFileSize = reports.Average(x => x.FileSize ?? 0)
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting report statistics: {ex.Message}", ex);
            }
        }
        #endregion
    }
}