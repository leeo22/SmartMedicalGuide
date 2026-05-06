using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IDoctorAppointmentRepository : IGenericRepositoryAsync<DoctorAppointment>
    {
        #region Basic Handlers
        Task<DoctorAppointment?> GetAppointmentByIdWithIncludesAsync(int id);
        Task<List<DoctorAppointment>> GetAllAppointmentsWithIncludesAsync();
        #endregion

        #region Additional Handlers
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
        // أضف هذه الدالة
        Task<int> GetTotalTreatedPatientsCountAsync(int doctorId);
        #endregion
    }
}