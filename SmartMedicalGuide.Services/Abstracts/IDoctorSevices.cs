using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IDoctorServices
    {
        public Task<List<Doctor>> GetDoctorsListAsync();
        public Task<string> AddAsync(Doctor doctor);
        public Task<Doctor> GetDoctorByIDAsync(int id);
        public Task<Doctor> GetDoctorByNAMEAsync(string name);
        public Task<string> EditAsync(Doctor doctor);
        public Task<string> DeleteAsync(Doctor doctor);
    }
}
