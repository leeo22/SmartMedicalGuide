using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface ILabRepository : IGenericRepositoryAsync<Lab>
    {
        Task<Lab?> GetLabByIdWithIncludesAsync(int id);
        Task<List<Lab>> GetAllLabsWithIncludesAsync();
        Task<Lab?> GetByUserIdAsync(int userId);
        Task<List<Lab>> GetByLocationAsync(string location);
        Task<List<Lab>> GetVerifiedLabsAsync();
        Task<List<Lab>> SearchLabsAsync(string keyword);
        Task<Lab?> GetLabWithServicesAsync(int id);
        Task<List<Lab>> GetActiveLabsAsync();
        Task<List<Lab>> GetLabsByServiceIdAsync(int serviceId);
    }
}