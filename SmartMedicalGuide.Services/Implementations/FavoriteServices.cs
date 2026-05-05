using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class FavoriteServices : IFavoriteServices
    {
        #region Fields
        private readonly IFavoriteRepository _favoriteRepository;
        #endregion

        #region Constructors
        public FavoriteServices(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<Favorite>> GetListAsync()
        {
            try
            {
                return await _favoriteRepository.GetAllFavoritesWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting favorites list: {ex.Message}", ex);
            }
        }

        public async Task<Favorite?> GetByIDAsync(int id)
        {
            try
            {
                return await _favoriteRepository.GetFavoriteByIdWithIncludesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting favorite by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(Favorite favorite)
        {
            try
            {
                var exists = await _favoriteRepository.IsFavoriteAsync(favorite.PatientId, favorite.DoctorId);
                if (exists)
                    return "Doctor already in favorites";

                favorite.CreatedAt = DateTime.UtcNow;
                favorite.IsDeleted = false;

                await _favoriteRepository.AddAsync(favorite);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add favorite: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(Favorite favorite)
        {
            try
            {
                favorite.IsDeleted = true;
                await _favoriteRepository.UpdateAsync(favorite);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete favorite: {ex.Message}";
            }
        }
        #endregion

        #region Additional Important Functions
        public async Task<List<Favorite>> GetByPatientIdAsync(int patientId)
        {
            try
            {
                return await _favoriteRepository.GetByPatientIdAsync(patientId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting favorites for patient {patientId}: {ex.Message}", ex);
            }
        }

        public async Task<bool> IsFavoriteAsync(int patientId, int doctorId)
        {
            try
            {
                return await _favoriteRepository.IsFavoriteAsync(patientId, doctorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking favorite status: {ex.Message}", ex);
            }
        }

        public async Task<List<Favorite>> GetFavoriteDoctorsWithDetailsAsync(int patientId)
        {
            try
            {
                return await _favoriteRepository.GetFavoriteDoctorsWithDetailsAsync(patientId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting favorite doctors with details for patient {patientId}: {ex.Message}", ex);
            }
        }

        public async Task<bool> ToggleFavoriteAsync(int patientId, int doctorId)
        {
            try
            {
                var existing = await _favoriteRepository.GetTableAsTracking()
                    .FirstOrDefaultAsync(x => x.PatientId == patientId && x.DoctorId == doctorId && !x.IsDeleted);

                if (existing != null)
                {
                    existing.IsDeleted = true;
                    await _favoriteRepository.UpdateAsync(existing);
                    return false; // تمت الإزالة
                }
                else
                {
                    var newFavorite = new Favorite
                    {
                        PatientId = patientId,
                        DoctorId = doctorId,
                        CreatedAt = DateTime.UtcNow,
                        IsDeleted = false
                    };
                    await _favoriteRepository.AddAsync(newFavorite);
                    return true; // تمت الإضافة
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error toggling favorite: {ex.Message}", ex);
            }
        }

        public async Task<int> GetFavoriteCountByDoctorAsync(int doctorId)
        {
            try
            {
                return await _favoriteRepository.GetFavoriteCountByDoctorAsync(doctorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting favorite count for doctor {doctorId}: {ex.Message}", ex);
            }
        }
        #endregion
    }
}