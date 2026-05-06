using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface ILabServiceServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<LabService>> GetListAsync();
        Task<LabService?> GetByIDAsync(int id);
        Task<string> AddAsync(LabService service);
        Task<string> EditAsync(LabService service);
        Task<string> DeleteAsync(LabService service);
        #endregion

        #region Additional Important Functions - 5 Functions
        Task<List<LabService>> GetByLabIdAsync(int labId);
        Task<List<LabService>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<List<LabService>> SearchServicesAsync(string keyword);
        Task<List<LabService>> GetLabServicesWithLabAsync(int labId);
        Task<List<LabService>> GetActiveServicesAsync();
        #endregion
    }
}