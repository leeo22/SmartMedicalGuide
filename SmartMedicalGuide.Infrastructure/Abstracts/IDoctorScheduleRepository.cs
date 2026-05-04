using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IDoctorScheduleRepository : IGenericRepositoryAsync<DoctorSchedule>
    {
        Task<DoctorSchedule?> GetScheduleByIdWithIncludesAsync(int id);
        Task<List<DoctorSchedule>> GetAllSchedulesWithIncludesAsync();
        Task<List<DoctorSchedule>> GetByDoctorIdAsync(int doctorId);
        Task<List<DoctorSchedule>> GetByDayOfWeekAsync(string dayOfWeek);
        Task<DoctorSchedule?> GetDoctorScheduleByDayAsync(int doctorId, string dayOfWeek);
        Task<List<TimeSpan>> GetDoctorAvailableSlotsAsync(int doctorId, DateTime date);
        Task<bool> CheckDoctorAvailableAsync(int doctorId, DateTime dateTime);
        Task<DoctorSchedule?> GetActiveScheduleByDoctorAndDayAsync(int? doctorId, string dayOfWeek);
        Task<DateTime?> GetNextAvailableSlotAsync(int doctorId);
    }
}