using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class LabServiceServices : ILabServiceServices
    {
        #region Fields
        private readonly ILabServiceRepository _serviceRepository;
        #endregion

        #region Constructors
        public LabServiceServices(ILabServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<LabService>> GetListAsync()
        {
            try
            {
                return await _serviceRepository.GetAllServicesWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting lab services list: {ex.Message}", ex);
            }
        }

        public async Task<LabService?> GetByIDAsync(int id)
        {
            try
            {
                return await _serviceRepository.GetServiceByIdWithIncludesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting lab service by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(LabService service)
        {
            try
            {
                service.IsActive = true;
                service.IsDeleted = false;

                await _serviceRepository.AddAsync(service);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add lab service: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(LabService service)
        {
            try
            {
                var existing = await _serviceRepository.GetTableAsTracking()
                    .FirstOrDefaultAsync(x => x.ServiceId == service.ServiceId && !x.IsDeleted);

                if (existing == null)
                    return "Service not found";

                existing.ServiceName = service.ServiceName ?? existing.ServiceName;
                existing.Description = service.Description ?? existing.Description;
                existing.Price = service.Price;
                existing.Category = service.Category ?? existing.Category;
                existing.Duration = service.Duration ?? existing.Duration;
                existing.ImageUrl = service.ImageUrl ?? existing.ImageUrl;
                existing.DiscountPercentage = service.DiscountPercentage ?? existing.DiscountPercentage;
                existing.IsActive = service.IsActive;

                await _serviceRepository.UpdateAsync(existing);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit lab service: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(LabService service)
        {
            try
            {
                service.IsDeleted = true;
                await _serviceRepository.UpdateAsync(service);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete lab service: {ex.Message}";
            }
        }
        #endregion

        #region Additional Important Functions
        public async Task<List<LabService>> GetByLabIdAsync(int labId)
        {
            try
            {
                return await _serviceRepository.GetByLabIdAsync(labId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting services for lab {labId}: {ex.Message}", ex);
            }
        }

        public async Task<List<LabService>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            try
            {
                return await _serviceRepository.GetByPriceRangeAsync(minPrice, maxPrice);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting services by price range {minPrice} - {maxPrice}: {ex.Message}", ex);
            }
        }

        public async Task<List<LabService>> SearchServicesAsync(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return await GetListAsync();

                return await _serviceRepository.SearchServicesAsync(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error searching services with keyword {keyword}: {ex.Message}", ex);
            }
        }

        public async Task<List<LabService>> GetLabServicesWithLabAsync(int labId)
        {
            try
            {
                return await _serviceRepository.GetLabServicesWithLabAsync(labId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting lab services with lab details for lab {labId}: {ex.Message}", ex);
            }
        }

        public async Task<List<LabService>> GetActiveServicesAsync()
        {
            try
            {
                return await _serviceRepository.GetActiveServicesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting active lab services: {ex.Message}", ex);
            }
        }
        #endregion
    }
}