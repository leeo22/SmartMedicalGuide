using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IDoctorScheduleServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<DoctorSchedule>> GetListAsync();
        Task<DoctorSchedule?> GetByIDAsync(int id);
        Task<string> AddAsync(DoctorSchedule schedule);
        Task<string> EditAsync(DoctorSchedule schedule);
        Task<string> DeleteAsync(DoctorSchedule schedule);
        #endregion

        #region Additional Important Functions - 5 Functions
        Task<List<DoctorSchedule>> GetByDoctorIdAsync(int doctorId);
        Task<List<DoctorSchedule>> GetByDayOfWeekAsync(string dayOfWeek);
        Task<DoctorSchedule?> GetDoctorScheduleByDayAsync(int doctorId, string dayOfWeek);
        Task<List<TimeSpan>> GetDoctorAvailableSlotsAsync(int doctorId, DateTime date);
        Task<bool> CheckDoctorAvailableAsync(int doctorId, DateTime dateTime);
        #endregion
    }
}