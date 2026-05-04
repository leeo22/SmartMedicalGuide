using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface ISpecializationRepository : IGenericRepositoryAsync<Specialization>
    {
        #region Basic Handlers
        Task<Specialization?> GetSpecializationByIdWithIncludesAsync(int id);
        Task<List<Specialization>> GetAllSpecializationsWithIncludesAsync();
        #endregion

        #region Additional Handlers
        Task<Specialization?> GetByNameAsync(string name);
        Task<List<Specialization>> SearchSpecializationsAsync(string keyword);
        Task<int> GetDoctorsCountBySpecializationAsync(int specializationId);
        Task<Specialization?> GetSpecializationWithDetailsAsync(int id);
        #endregion
    }
}