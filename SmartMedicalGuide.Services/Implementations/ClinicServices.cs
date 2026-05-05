using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class ClinicServices : IClinicServices
    {
        #region Fields
        private readonly IClinicRepository _clinicRepository;
        #endregion

        #region Constructors
        public ClinicServices(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<Clinic>> GetListAsync()
        {
            try
            {
                return await _clinicRepository.GetAllClinicsWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting clinics list: {ex.Message}", ex);
            }
        }

        public async Task<Clinic?> GetByIDAsync(int id)
        {
            try
            {
                return await _clinicRepository.GetClinicByIdWithIncludesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting clinic by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(Clinic clinic)
        {
            try
            {
                clinic.IsActive = true;
                clinic.IsDeleted = false;

                await _clinicRepository.AddAsync(clinic);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add clinic: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(Clinic clinic)
        {
            try
            {
                var existing = await _clinicRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.ClinicId == clinic.ClinicId && !x.IsDeleted);

                if (existing == null)
                    return "Clinic not found";

                existing.ClinicName = clinic.ClinicName ?? existing.ClinicName;
                existing.Location = clinic.Location ?? existing.Location;
                existing.PhoneNumber = clinic.PhoneNumber ?? existing.PhoneNumber;
                existing.Description = clinic.Description ?? existing.Description;
                existing.ClinicImageUrl = clinic.ClinicImageUrl ?? existing.ClinicImageUrl;
                existing.Email = clinic.Email ?? existing.Email;
                existing.Latitude = clinic.Latitude ?? existing.Latitude;
                existing.Longitude = clinic.Longitude ?? existing.Longitude;
                existing.OpeningTime = clinic.OpeningTime ?? existing.OpeningTime;
                existing.ClosingTime = clinic.ClosingTime ?? existing.ClosingTime;
                existing.IsActive = clinic.IsActive;

                await _clinicRepository.UpdateAsync(existing);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit clinic: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(Clinic clinic)
        {
            try
            {
                clinic.IsDeleted = true;
                await _clinicRepository.UpdateAsync(clinic);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete clinic: {ex.Message}";
            }
        }
        #endregion

        #region Additional Important Functions
        public async Task<List<Clinic>> GetByDoctorIdAsync(int doctorId)
        {
            try
            {
                return await _clinicRepository.GetByDoctorIdAsync(doctorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting clinics for doctor {doctorId}: {ex.Message}", ex);
            }
        }

        public async Task<List<Clinic>> GetByLocationAsync(string location)
        {
            try
            {
                return await _clinicRepository.GetByLocationAsync(location);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting clinics by location {location}: {ex.Message}", ex);
            }
        }

        public async Task<List<Clinic>> SearchClinicsAsync(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return await GetListAsync();

                return await _clinicRepository.SearchClinicsAsync(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error searching clinics with keyword {keyword}: {ex.Message}", ex);
            }
        }

        public async Task<Clinic?> GetClinicWithDoctorAsync(int id)
        {
            try
            {
                return await _clinicRepository.GetClinicWithDoctorAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting clinic with doctor for ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<List<Clinic>> GetActiveClinicsAsync()
        {
            try
            {
                return await _clinicRepository.GetActiveClinicsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting active clinics: {ex.Message}", ex);
            }
        }
        #endregion
    }
}