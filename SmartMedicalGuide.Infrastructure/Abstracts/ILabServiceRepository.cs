using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface ILabServiceRepository : IGenericRepositoryAsync<LabService>
    {
        Task<LabService?> GetServiceByIdWithIncludesAsync(int id);
        Task<List<LabService>> GetAllServicesWithIncludesAsync();
        Task<List<LabService>> GetByLabIdAsync(int labId);
        Task<List<LabService>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<List<LabService>> SearchServicesAsync(string keyword);
        Task<List<LabService>> GetActiveServicesAsync();
        Task<List<LabService>> GetLabServicesWithLabAsync(int labId);
    }
}