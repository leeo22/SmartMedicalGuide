using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IPatientRepository : IGenericRepositoryAsync<Patient>
    {
        public Task<List<Patient>> GetPatientsListAsync();
    }
}
