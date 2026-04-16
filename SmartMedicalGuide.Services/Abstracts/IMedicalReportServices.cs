using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IMedicalReportServices
    {
        public Task<List<MedicalReport>> GetListAsync();
        public Task<MedicalReport> GetByIDAsync(int id);
        public Task<string> AddAsync(MedicalReport medicalReport);
        public Task<string> EditAsync(MedicalReport medicalReport);
        public Task<string> DeleteAsync(MedicalReport medicalReport);
        public Task<List<MedicalReport>> GetByPatientIdAsync(int patientId);
        public Task<List<MedicalReport>> GetByDoctorIdAsync(int doctorId);
        public Task<List<MedicalReport>> GetByLabIdAsync(int labId);
    }
}