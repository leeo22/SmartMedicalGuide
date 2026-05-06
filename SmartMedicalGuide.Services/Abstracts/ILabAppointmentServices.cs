using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface ILabAppointmentServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<LabAppointment>> GetListAsync();
        Task<LabAppointment?> GetByIDAsync(int id);
        Task<string> AddAsync(LabAppointment appointment);
        Task<string> EditAsync(LabAppointment appointment);
        Task<string> DeleteAsync(LabAppointment appointment);
        #endregion

        #region Additional Important Functions - 6 Functions
        Task<List<LabAppointment>> GetByLabIdAsync(int labId);
        Task<List<LabAppointment>> GetByPatientIdAsync(int patientId);
        Task<List<LabAppointment>> GetByStatusAsync(string status);
        Task<List<LabAppointment>> GetLabUpcomingAppointmentsAsync(int labId);
        Task<List<LabAppointment>> GetPatientUpcomingAppointmentsAsync(int patientId);
        Task<bool> CheckLabAvailabilityAsync(int labId, DateTime appointmentDate);
        #endregion
    }
}