using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IDoctorServices : IGenericRepositoryAsync<Doctor>
    {
        public Task<List<Doctor>> GetAllDoctorListAsync();
    }
}
