using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface ILabServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<Lab>> GetListAsync();
        Task<Lab?> GetByIDAsync(int id);
        Task<string> AddAsync(Lab lab);
        Task<string> EditAsync(Lab lab);
        Task<string> DeleteAsync(Lab lab);
        #endregion

        #region Additional Important Functions - 5 Functions
        Task<Lab?> GetByUserIdAsync(int userId);
        Task<List<Lab>> GetByLocationAsync(string location);
        Task<List<Lab>> GetVerifiedLabsAsync();
        Task<List<Lab>> SearchLabsAsync(string keyword);
        Task<Lab?> GetLabWithServicesAsync(int id);
        #endregion
    }
}