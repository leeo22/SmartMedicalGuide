using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IPrescriptionRepository : IGenericRepositoryAsync<Prescription>
    {
        Task<Prescription?> GetPrescriptionByIdWithIncludesAsync(int id);
        Task<List<Prescription>> GetAllPrescriptionsWithIncludesAsync();
        Task<List<Prescription>> GetByPatientIdAsync(int patientId);
        Task<List<Prescription>> GetByDoctorIdAsync(int doctorId);
        Task<Prescription?> GetByAppointmentIdAsync(int appointmentId);
        Task<List<Prescription>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);
        Task<Prescription?> GetPrescriptionWithItemsAsync(int id);
        Task<object> GetPrescriptionStatisticsAsync();
    }
}