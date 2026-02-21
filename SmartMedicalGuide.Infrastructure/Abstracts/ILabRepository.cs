using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface ILabRepository : IGenericRepositoryAsync<Lab>
    {
        public Task<List<Lab>> GetLabsListAsync();
    }
}
