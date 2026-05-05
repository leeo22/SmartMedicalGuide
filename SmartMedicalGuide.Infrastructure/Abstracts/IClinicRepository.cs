using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IClinicRepository : IGenericRepositoryAsync<Clinic>
    {
        Task<Clinic?> GetClinicByIdWithIncludesAsync(int id);
        Task<List<Clinic>> GetAllClinicsWithIncludesAsync();
        Task<List<Clinic>> GetByDoctorIdAsync(int doctorId);
        Task<List<Clinic>> GetByLocationAsync(string location);
        Task<List<Clinic>> SearchClinicsAsync(string keyword);
        Task<Clinic?> GetClinicWithDoctorAsync(int id);
        Task<List<Clinic>> GetActiveClinicsAsync();
    }
}