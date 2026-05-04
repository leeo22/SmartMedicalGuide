using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IDoctorCapacitySettingRepository : IGenericRepositoryAsync<DoctorCapacitySetting>
    {
        // Get by DoctorId
        Task<DoctorCapacitySetting?> GetByDoctorIdAsync(int doctorId);

        // Get active settings by DoctorId
        Task<DoctorCapacitySetting?> GetActiveByDoctorIdAsync(int doctorId);

        // Get settings by ShiftType
        Task<List<DoctorCapacitySetting>> GetByShiftTypeAsync(ShiftType shiftType);

        // Get settings by BookingType
        Task<List<DoctorCapacitySetting>> GetByBookingTypeAsync(BookingType bookingType);

        // Get doctors by minimum capacity
        Task<List<DoctorCapacitySetting>> GetDoctorsByMinCapacityAsync(int minCapacity);

        // Get capacity report for a date range (for Admin)
        Task<List<DoctorCapacitySetting>> GetCapacityReportAsync(DateTime? fromDate, DateTime? toDate);

        // Bulk update
        Task<bool> BulkUpdateAsync(List<DoctorCapacitySetting> settings);
    }
}