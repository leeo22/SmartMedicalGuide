using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IPatientServices
    {
        public Task<List<Patient>> GetPatientsListAsync();
        public Task<Patient> GetPatientByIdAsync(int id);
        public Task<string> AddAsync(Patient patient);
        public Task<bool> IsPhoneExist(string phone);
        public Task<bool> IsPhoneExistExcludeSelf(string phone, int Id);
        public Task<string> EditAsync(Patient patient);
        public Task<string> DeleteAsync(Patient patient);

    }
}
