using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IFavoriteServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<Favorite>> GetListAsync();
        Task<Favorite?> GetByIDAsync(int id);
        Task<string> AddAsync(Favorite favorite);
        Task<string> DeleteAsync(Favorite favorite);
        #endregion

        #region Additional Important Functions - 5 Functions
        Task<List<Favorite>> GetByPatientIdAsync(int patientId);
        Task<bool> IsFavoriteAsync(int patientId, int doctorId);
        Task<List<Favorite>> GetFavoriteDoctorsWithDetailsAsync(int patientId);
        Task<bool> ToggleFavoriteAsync(int patientId, int doctorId);
        Task<int> GetFavoriteCountByDoctorAsync(int doctorId);
        #endregion
    }
}