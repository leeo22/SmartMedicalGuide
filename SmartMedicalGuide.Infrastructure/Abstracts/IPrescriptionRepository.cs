using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IPrescriptionRepository : IGenericRepositoryAsync<Prescription>
    {
        //public Task<List<Prescription>> GetPrescriptionsListAsync();
    }
}
