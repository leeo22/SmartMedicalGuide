using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IDoctorAppointmentServices
    {
        public Task<List<DoctorAppointment>> GetDoctorAppointmentsListAsync();
    }
}
