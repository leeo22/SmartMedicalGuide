using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class DoctorCapacitySettingServices : IDoctorCapacitySettingServices
    {
        #region Fields
        private readonly IDoctorCapacitySettingRepository _repository;
        private readonly IDoctorAppointmentRepository _appointmentRepository;
        #endregion

        #region Constructors
        public DoctorCapacitySettingServices(
            IDoctorCapacitySettingRepository repository,
            IDoctorAppointmentRepository appointmentRepository)
        {
            _repository = repository;
            _appointmentRepository = appointmentRepository;
        }
        #endregion

        #region Basic CRUD
        public async Task<List<DoctorCapacitySetting>> GetListAsync()
        {
            return await _repository.GetTableAsTracking()
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .ToListAsync();
        }

        public async Task<DoctorCapacitySetting?> GetByIDAsync(int id)
        {
            return await _repository.GetByIdAsync()
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<string> AddAsync(DoctorCapacitySetting setting)
        {
            var existing = await _repository.GetByDoctorIdAsync(setting.DoctorId);
            if (existing != null)
                return "Setting already exists for this doctor";

            await _repository.AddAsync(setting);
            return "Success";
        }

        public async Task<string> EditAsync(DoctorCapacitySetting setting)
        {
            var existing = await _repository.GetByIdAsync(setting.Id);
            if (existing == null)
                return "Setting not found";

            existing.WorkDays = setting.WorkDays;
            existing.BookingType = setting.BookingType;
            existing.DailyCapacity = setting.DailyCapacity;
            existing.MaxLimit = setting.MaxLimit;
            existing.ShiftType = setting.ShiftType;
            existing.IsActive = setting.IsActive;

            await _repository.UpdateAsync(existing);
            return "Success";
        }

        public async Task<string> DeleteAsync(DoctorCapacitySetting setting)
        {
            var trans = _repository.BeginTransaction();
            try
            {
                await _repository.DeleteAsync(setting);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }
        #endregion

        #region Additional Business Functions
        public async Task<DoctorCapacitySetting?> GetByDoctorIdAsync(int doctorId)
        {
            return await _repository.GetTableAsTracking()
                .Include(x => x.Doctor)
                    .ThenInclude(d => d.User)
                .FirstOrDefaultAsync(x => x.DoctorId == doctorId);
        }

        public async Task<DoctorCapacitySetting?> GetActiveByDoctorIdAsync(int doctorId)
        {
            return await _repository.GetActiveByDoctorIdAsync(doctorId);
        }

        public async Task<int> GetRemainingCapacityAsync(int doctorId, DateTime appointmentDate)
        {
            var setting = await _repository.GetActiveByDoctorIdAsync(doctorId);
            if (setting == null)
                return 0;

            // Get booked appointments count for this doctor on this date
            var bookedCount = await _appointmentRepository.GetTableAsTracking()
                .CountAsync(x => x.DoctorId == doctorId
                    && x.AppointmentDate.HasValue
                    && x.AppointmentDate.Value.Date == appointmentDate.Date
                    && x.Status != "Cancelled");

            return setting.DailyCapacity - bookedCount;
        }

        public async Task<bool> CheckAvailabilityAsync(int doctorId, DateTime appointmentDate)
        {
            var remaining = await GetRemainingCapacityAsync(doctorId, appointmentDate);
            return remaining > 0;
        }

        public async Task<bool> DecrementDailyCapacityAsync(int doctorId)
        {
            var setting = await _repository.GetActiveByDoctorIdAsync(doctorId);
            if (setting == null || setting.DailyCapacity <= 0)
                return false;

            setting.DailyCapacity--;
            await _repository.UpdateAsync(setting);
            return true;
        }

        public async Task<List<DoctorCapacitySetting>> GetCapacityReportAsync(DateTime? fromDate, DateTime? toDate)
        {
            return await _repository.GetCapacityReportAsync(fromDate, toDate);
        }

        public async Task<bool> BulkUpdateAsync(List<DoctorCapacitySetting> settings)
        {
            return await _repository.BulkUpdateAsync(settings);
        }

        public async Task<List<DoctorCapacitySetting>> GetDoctorsByCapacityAsync(int minCapacity)
        {
            return await _repository.GetDoctorsByMinCapacityAsync(minCapacity);
        }

        public async Task<List<DoctorCapacitySetting>> GetByShiftTypeAsync(ShiftType shiftType)
        {
            return await _repository.GetByShiftTypeAsync(shiftType);
        }

        public async Task<List<DoctorCapacitySetting>> GetByBookingTypeAsync(BookingType bookingType)
        {
            return await _repository.GetByBookingTypeAsync(bookingType);
        }
        #endregion
    }
}