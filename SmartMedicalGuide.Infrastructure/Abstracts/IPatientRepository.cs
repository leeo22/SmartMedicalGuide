using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IPatientRepository : IGenericRepositoryAsync<Patient>
    {
        Task<Patient?> GetPatientByIdWithIncludesAsync(int id);
        Task<List<Patient>> GetAllPatientsWithIncludesAsync();
        Task<Patient?> GetByUserIdAsync(int userId);
        Task<List<Patient>> SearchPatientsAsync(string keyword);
    }
}