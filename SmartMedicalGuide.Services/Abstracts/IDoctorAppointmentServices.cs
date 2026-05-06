using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IDoctorAppointmentServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<DoctorAppointment>> GetListAsync();
        Task<DoctorAppointment?> GetByIDAsync(int id);
        Task<string> AddAsync(DoctorAppointment appointment);
        Task<string> EditAsync(DoctorAppointment appointment);
        Task<string> DeleteAsync(DoctorAppointment appointment);
        #endregion

        #region Additional Functions - 10 Functions
        Task<List<DoctorAppointment>> GetByDoctorIdAsync(int doctorId);
        Task<List<DoctorAppointment>> GetByPatientIdAsync(int patientId);
        Task<List<DoctorAppointment>> GetByDateAsync(DateTime date);
        Task<List<DoctorAppointment>> GetByStatusAsync(string status);
        Task<List<DoctorAppointment>> GetDoctorUpcomingAppointmentsAsync(int doctorId);
        Task<List<DoctorAppointment>> GetPatientUpcomingAppointmentsAsync(int patientId);
        Task<List<DoctorAppointment>> GetDoctorTodayAppointmentsAsync(int doctorId);
        Task<List<DoctorAppointment>> GetDoctorAppointmentsByDateRangeAsync(int doctorId, DateTime fromDate, DateTime toDate);

        Task<int> GetDoctorAppointmentsCountAsync(int doctorId);
        Task<bool> CheckDoctorAvailabilityAsync(int doctorId, DateTime appointmentDate);
        Task<object> GetAppointmentsReportAsync(DateTime? fromDate, DateTime? toDate);
        Task<string> CancelAppointmentAsync(int appointmentId, string? cancellationReason = null, int? rescheduledByUserId = null);
        Task<string> ConfirmAppointmentAsync(int appointmentId);
        Task<string> CompleteAppointmentAsync(int appointmentId);
        Task<string> RescheduleAppointmentAsync(int appointmentId, DateTime newDate, string? reason = null, int? rescheduledByUserId = null);
        #endregion
    }
}