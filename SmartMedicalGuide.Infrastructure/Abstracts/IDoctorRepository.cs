using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IDoctorRepository : IGenericRepositoryAsync<Doctor>
    {
        // Get Doctor with Includes
        Task<Doctor?> GetDoctorByIdWithIncludesAsync(int id);
        Task<List<Doctor>> GetAllDoctorsWithIncludesAsync();

        // Additional Functions
        Task<Doctor?> GetByUserIdAsync(int userId);
        Task<List<Doctor>> GetBySpecializationIdAsync(int specializationId);
        Task<List<Doctor>> GetVerifiedDoctorsAsync();
        Task<List<Doctor>> SearchDoctorsAsync(string keyword);
        Task<List<Doctor>> GetTopRatedDoctorsAsync(int limit);
        Task<List<Doctor>> GetDoctorsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<Doctor?> GetDoctorWithDetailsAsync(int id);
        Task<List<Doctor>> GetAvailableForBookingDoctorsAsync();
    }
}