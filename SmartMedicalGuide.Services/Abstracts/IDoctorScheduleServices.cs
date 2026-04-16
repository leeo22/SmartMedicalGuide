using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IDoctorScheduleServices
    {
        public Task<List<DoctorSchedule>> GetListAsync();
        public Task<DoctorSchedule> GetByIDAsync(int id);
        public Task<string> AddAsync(DoctorSchedule doctorSchedule);
        public Task<string> EditAsync(DoctorSchedule doctorSchedule);
        public Task<string> DeleteAsync(DoctorSchedule doctorSchedule);
        public Task<List<DoctorSchedule>> GetByDoctorIdAsync(int doctorId);
        public Task<List<DoctorSchedule>> GetByDoctorIdAndDayAsync(int doctorId, string dayOfWeek);
        public Task<bool> IsTimeSlotAvailableAsync(int doctorId, string dayOfWeek, DateTime startTime, DateTime endTime);
    }
}