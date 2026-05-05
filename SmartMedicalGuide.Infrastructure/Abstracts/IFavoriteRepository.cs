using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IFavoriteRepository : IGenericRepositoryAsync<Favorite>
    {
        Task<Favorite?> GetFavoriteByIdWithIncludesAsync(int id);
        Task<List<Favorite>> GetAllFavoritesWithIncludesAsync();
        Task<List<Favorite>> GetByPatientIdAsync(int patientId);
        Task<List<Favorite>> GetByDoctorIdAsync(int doctorId);
        Task<bool> IsFavoriteAsync(int patientId, int doctorId);
        Task<List<Favorite>> GetFavoriteDoctorsWithDetailsAsync(int patientId);
        Task<int> GetFavoriteCountByDoctorAsync(int doctorId);
        Task<List<Favorite>> GetMostFavoriteDoctorsAsync(int limit);
        Task<bool> DeleteAllByPatientAsync(int patientId);
    }
}