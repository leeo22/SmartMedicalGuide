using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface ILabAppointmentRepository : IGenericRepositoryAsync<LabAppointment>
    {
        Task<LabAppointment?> GetAppointmentByIdWithIncludesAsync(int id);
        Task<List<LabAppointment>> GetAllAppointmentsWithIncludesAsync();
        Task<List<LabAppointment>> GetByLabIdAsync(int labId);
        Task<List<LabAppointment>> GetByPatientIdAsync(int patientId);
        Task<List<LabAppointment>> GetByDateAsync(DateTime date);
        Task<List<LabAppointment>> GetByStatusAsync(string status);
        Task<List<LabAppointment>> GetLabUpcomingAppointmentsAsync(int labId);
        Task<List<LabAppointment>> GetPatientUpcomingAppointmentsAsync(int patientId);
        Task<List<LabAppointment>> GetLabTodayAppointmentsAsync(int labId);
        Task<bool> CheckLabAvailabilityAsync(int labId, DateTime appointmentDate);
        Task<string> CancelAppointmentAsync(int appointmentId, string? cancellationReason = null, int? rescheduledByUserId = null);
        Task<string> ConfirmAppointmentAsync(int appointmentId);
        Task<string> CompleteAppointmentAsync(int appointmentId);
    }
}