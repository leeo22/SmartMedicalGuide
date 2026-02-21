using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IDoctorAppointmentServices
    {
        public Task<List<DoctorAppointment>> GetDoctorAppointmentsListAsync();
        public Task<string> AddAsync(DoctorAppointment doctorAppointment);
        public Task<DoctorAppointment> GetDoctorAppointmentByIDAsync(int id);
        public Task<string> EditAsync(DoctorAppointment doctorAppointment);
        public Task<string> DeleteAsync(DoctorAppointment doctorAppointment);

    }
}
