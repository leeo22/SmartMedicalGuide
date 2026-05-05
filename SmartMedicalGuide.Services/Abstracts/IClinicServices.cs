using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IClinicServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<Clinic>> GetListAsync();
        Task<Clinic?> GetByIDAsync(int id);
        Task<string> AddAsync(Clinic clinic);
        Task<string> EditAsync(Clinic clinic);
        Task<string> DeleteAsync(Clinic clinic);
        #endregion

        #region Additional Important Functions - 5 Functions
        Task<List<Clinic>> GetByDoctorIdAsync(int doctorId);
        Task<List<Clinic>> GetByLocationAsync(string location);
        Task<List<Clinic>> SearchClinicsAsync(string keyword);
        Task<Clinic?> GetClinicWithDoctorAsync(int id);
        Task<List<Clinic>> GetActiveClinicsAsync();
        #endregion
    }
}