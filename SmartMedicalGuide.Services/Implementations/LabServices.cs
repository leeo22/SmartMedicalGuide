using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class LabServices : ILabServices
    {
        #region Fields
        private readonly ILabRepository _labRepository;
        #endregion

        #region Constructors
        public LabServices(ILabRepository labRepository)
        {
            _labRepository = labRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<Lab>> GetListAsync()
        {
            try
            {
                return await _labRepository.GetAllLabsWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting labs list: {ex.Message}", ex);
            }
        }

        public async Task<Lab?> GetByIDAsync(int id)
        {
            try
            {
                return await _labRepository.GetLabByIdWithIncludesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting lab by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(Lab lab)
        {
            try
            {
                lab.IsActive = true;
                lab.IsDeleted = false;
                lab.VerificationStatus = "Pending";

                await _labRepository.AddAsync(lab);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add lab: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(Lab lab)
        {
            try
            {
                var existing = await _labRepository.GetTableAsTracking()
                    .FirstOrDefaultAsync(x => x.LabId == lab.LabId && !x.IsDeleted);

                if (existing == null)
                    return "Lab not found";

                existing.CenterName = lab.CenterName ?? existing.CenterName;
                existing.CenterType = lab.CenterType ?? existing.CenterType;
                existing.PhoneNumber = lab.PhoneNumber ?? existing.PhoneNumber;
                existing.Location = lab.Location ?? existing.Location;
                existing.LicenseNumber = lab.LicenseNumber ?? existing.LicenseNumber;
                existing.Description = lab.Description ?? existing.Description;
                existing.Email = lab.Email ?? existing.Email;
                existing.LabImageUrl = lab.LabImageUrl ?? existing.LabImageUrl;
                existing.Latitude = lab.Latitude ?? existing.Latitude;
                existing.Longitude = lab.Longitude ?? existing.Longitude;
                existing.WorkingHours = lab.WorkingHours ?? existing.WorkingHours;
                existing.IsActive = lab.IsActive;

                await _labRepository.UpdateAsync(existing);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit lab: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(Lab lab)
        {
            try
            {
                lab.IsDeleted = true;
                await _labRepository.UpdateAsync(lab);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete lab: {ex.Message}";
            }
        }
        #endregion

        #region Additional Important Functions
        public async Task<Lab?> GetByUserIdAsync(int userId)
        {
            try
            {
                return await _labRepository.GetByUserIdAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting lab for user {userId}: {ex.Message}", ex);
            }
        }

        public async Task<List<Lab>> GetByLocationAsync(string location)
        {
            try
            {
                return await _labRepository.GetByLocationAsync(location);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting labs by location {location}: {ex.Message}", ex);
            }
        }

        public async Task<List<Lab>> GetVerifiedLabsAsync()
        {
            try
            {
                return await _labRepository.GetVerifiedLabsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting verified labs: {ex.Message}", ex);
            }
        }

        public async Task<List<Lab>> SearchLabsAsync(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return await GetListAsync();

                return await _labRepository.SearchLabsAsync(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error searching labs with keyword {keyword}: {ex.Message}", ex);
            }
        }

        public async Task<Lab?> GetLabWithServicesAsync(int id)
        {
            try
            {
                return await _labRepository.GetLabWithServicesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting lab with services for ID {id}: {ex.Message}", ex);
            }
        }
        #endregion
    }
}