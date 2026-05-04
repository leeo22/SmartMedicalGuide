using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IPatientServices
    {
        // Basic CRUD - 5 Functions
        Task<List<Patient>> GetListAsync();
        Task<Patient?> GetByIDAsync(int id);
        Task<string> AddAsync(Patient patient);
        Task<string> EditAsync(Patient patient);
        Task<string> DeleteAsync(Patient patient);

        // Additional Functions - 11 Functions
        Task<Patient?> GetByUserIdAsync(int userId);
        Task<object> GetPatientAppointmentsAsync(int patientId);
        Task<object> GetPatientPrescriptionsAsync(int patientId);
        Task<object> GetPatientMedicalReportsAsync(int patientId);
        Task<object> GetPatientPaymentHistoryAsync(int patientId);
        Task<object> GetPatientUpcomingAppointmentsAsync(int patientId);
        Task<object> GetPatientPastAppointmentsAsync(int patientId);
        Task<object> GetPatientFavoriteDoctorsAsync(int patientId);
        Task<object> GetPatientReviewsAsync(int patientId);
        Task<object> GetPatientStatisticsAsync(int patientId);
        Task<string> UpdatePatientProfileAsync(int patientId, string? gender, DateTime? dateOfBirth, string? address);
        Task<List<Patient>> SearchPatientsAsync(string keyword);
    }
}