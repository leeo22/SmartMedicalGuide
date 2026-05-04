using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface ISpecializationServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<Specialization>> GetListAsync();
        Task<Specialization?> GetByIDAsync(int id);
        Task<string> AddAsync(Specialization specialization);
        Task<string> EditAsync(Specialization specialization);
        Task<string> DeleteAsync(Specialization specialization);
        #endregion

        #region Additional Functions - 7 Functions (High Priority)
        Task<Specialization?> GetByNameAsync(string name);
        Task<List<Specialization>> SearchSpecializationsAsync(string keyword);
        Task<int> GetDoctorsCountBySpecializationAsync(int specializationId);
        Task<Specialization?> GetSpecializationWithDetailsAsync(int id);
        Task<List<Specialization>> GetPopularSpecializationsAsync(int limit);
        Task<object> GetSpecializationStatisticsAsync(int specializationId);
        #endregion
    }
}