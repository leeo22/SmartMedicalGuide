using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IPrescriptionServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<Prescription>> GetListAsync();
        Task<Prescription?> GetByIDAsync(int id);
        Task<string> AddAsync(Prescription prescription);
        Task<string> EditAsync(Prescription prescription);
        Task<string> DeleteAsync(Prescription prescription);
        #endregion

        #region Additional Important Functions - 7 Functions
        Task<List<Prescription>> GetByPatientIdAsync(int patientId);
        Task<List<Prescription>> GetByDoctorIdAsync(int doctorId);
        Task<Prescription?> GetByAppointmentIdAsync(int appointmentId);
        Task<List<Prescription>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);
        Task<Prescription?> GetPrescriptionWithItemsAsync(int id);
        Task<object> GetPrescriptionStatisticsAsync();
        Task<string> UpdatePrescriptionStatusAsync(int prescriptionId, string status);
        #endregion
    }
}