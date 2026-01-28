using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IDoctorRepository : IGenericRepositoryAsync<Doctor>
    {
        public Task<List<Doctor>> GetDoctorsListAsync();
    }
}
