using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class DoctorCapacitySettingRepository : GenericRepositoryAsync<DoctorCapacitySetting>, IDoctorCapacitySettingRepository
    {
        #region Fields
        private readonly DbSet<DoctorCapacitySetting> _doctorCapacitySettings;
        private readonly MedicalGuideDbContext _dbContext;
        #endregion

        #region Constructors
        public DoctorCapacitySettingRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _doctorCapacitySettings = dbContext.Set<DoctorCapacitySetting>();
        }
        #endregion

        #region Handlers
        public async Task<DoctorCapacitySetting?> GetByDoctorIdAsync(int doctorId)
        {
            return await _doctorCapacitySettings
                .FirstOrDefaultAsync(x => x.DoctorId == doctorId);
        }

        public async Task<DoctorCapacitySetting?> GetActiveByDoctorIdAsync(int doctorId)
        {
            return await _doctorCapacitySettings
                .FirstOrDefaultAsync(x => x.DoctorId == doctorId && x.IsActive);
        }

        public async Task<List<DoctorCapacitySetting>> GetByShiftTypeAsync(ShiftType shiftType)
        {
            return await _doctorCapacitySettings
                .Where(x => x.ShiftType == shiftType)
                .Include(x => x.Doctor)
                .ToListAsync();
        }

        public async Task<List<DoctorCapacitySetting>> GetByBookingTypeAsync(BookingType bookingType)
        {
            return await _doctorCapacitySettings
                .Where(x => x.BookingType == bookingType)
                .Include(x => x.Doctor)
                .ToListAsync();
        }

        public async Task<List<DoctorCapacitySetting>> GetDoctorsByMinCapacityAsync(int minCapacity)
        {
            return await _doctorCapacitySettings
                .Where(x => x.DailyCapacity >= minCapacity && x.IsActive)
                .Include(x => x.Doctor)
                .ToListAsync();
        }

        public async Task<List<DoctorCapacitySetting>> GetCapacityReportAsync(DateTime? fromDate, DateTime? toDate)
        {
            var query = _doctorCapacitySettings.AsQueryable();

            if (fromDate.HasValue)
                query = query.Where(x => x.CreatedAt >= fromDate.Value);
            if (toDate.HasValue)
                query = query.Where(x => x.CreatedAt <= toDate.Value);

            return await query
                .Include(x => x.Doctor)
                .ToListAsync();
        }

        public async Task<bool> BulkUpdateAsync(List<DoctorCapacitySetting> settings)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                foreach (var setting in settings)
                {
                    var existing = await GetByDoctorIdAsync(setting.DoctorId);
                    if (existing != null)
                    {
                        existing.DailyCapacity = setting.DailyCapacity;
                        existing.MaxLimit = setting.MaxLimit;
                        existing.BookingType = setting.BookingType;
                        existing.ShiftType = setting.ShiftType;
                        existing.WorkDays = setting.WorkDays;
                        existing.IsActive = setting.IsActive;
                        _doctorCapacitySettings.Update(existing);
                    }
                    else
                    {
                        await _doctorCapacitySettings.AddAsync(setting);
                    }
                }
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
        #endregion
    }
}