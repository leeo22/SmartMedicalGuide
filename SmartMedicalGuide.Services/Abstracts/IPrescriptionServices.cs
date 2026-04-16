using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IPrescriptionServices
    {
        public Task<List<Prescription>> GetListAsync();
        public Task<Prescription> GetByIDAsync(int id);
        public Task<string> AddAsync(Prescription prescription);
        public Task<string> EditAsync(Prescription prescription);
        public Task<string> DeleteAsync(Prescription prescription);
        public Task<List<Prescription>> GetByPatientIdAsync(int patientId);
        public Task<List<Prescription>> GetByDoctorIdAsync(int doctorId);
        public Task<List<Prescription>> GetByAppointmentIdAsync(int appointmentId);
    }
}