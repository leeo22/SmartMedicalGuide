using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IAppointmentHistoryServices
    {
        public Task<List<AppointmentHistory>> GetListAsync();
        public Task<AppointmentHistory> GetByIDAsync(int id);
        public Task<string> AddAsync(AppointmentHistory appointmentHistory);
        public Task<string> EditAsync(AppointmentHistory appointmentHistory);
        public Task<string> DeleteAsync(AppointmentHistory appointmentHistory);
        public Task<List<AppointmentHistory>> GetByAppointmentIdAsync(int appointmentId, string appointmentType);
    }
}