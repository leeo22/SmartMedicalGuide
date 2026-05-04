using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IDoctorCapacitySettingServices
    {
        // Basic CRUD
        Task<List<DoctorCapacitySetting>> GetListAsync();
        Task<DoctorCapacitySetting?> GetByIDAsync(int id);
        Task<string> AddAsync(DoctorCapacitySetting setting);
        Task<string> EditAsync(DoctorCapacitySetting setting);
        Task<string> DeleteAsync(DoctorCapacitySetting setting);

        // Additional Business Functions
        Task<DoctorCapacitySetting?> GetByDoctorIdAsync(int doctorId);
        Task<DoctorCapacitySetting?> GetActiveByDoctorIdAsync(int doctorId);
        Task<int> GetRemainingCapacityAsync(int doctorId, DateTime appointmentDate);
        Task<bool> CheckAvailabilityAsync(int doctorId, DateTime appointmentDate);
        Task<bool> DecrementDailyCapacityAsync(int doctorId);
        Task<List<DoctorCapacitySetting>> GetCapacityReportAsync(DateTime? fromDate, DateTime? toDate);
        Task<bool> BulkUpdateAsync(List<DoctorCapacitySetting> settings);
        Task<List<DoctorCapacitySetting>> GetDoctorsByCapacityAsync(int minCapacity);
        Task<List<DoctorCapacitySetting>> GetByShiftTypeAsync(ShiftType shiftType);
        Task<List<DoctorCapacitySetting>> GetByBookingTypeAsync(BookingType bookingType);
    }
}