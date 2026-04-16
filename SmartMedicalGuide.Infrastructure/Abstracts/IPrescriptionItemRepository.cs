using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IPrescriptionItemRepository : IGenericRepositoryAsync<PrescriptionItem>
    {
        //public Task<List<PrescriptionItem>> GetPrescriptionItemsListAsync();
    }
}
