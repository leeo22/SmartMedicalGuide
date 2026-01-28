using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IDoctorServices
    {
        public Task<List<Doctor>> GetDoctorsListAsync();
        public Task<string> AddAsync(Doctor doctor);
    }
}
