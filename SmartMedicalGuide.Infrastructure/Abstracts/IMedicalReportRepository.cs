using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IMedicalReportRepository : IGenericRepositoryAsync<MedicalReport>
    {
        Task<MedicalReport?> GetReportByIdWithIncludesAsync(int id);
        Task<List<MedicalReport>> GetAllReportsWithIncludesAsync();
        Task<List<MedicalReport>> GetByPatientIdAsync(int patientId);
        Task<List<MedicalReport>> GetByDoctorIdAsync(int doctorId);
        Task<List<MedicalReport>> GetByReportTypeAsync(string reportType);
        Task<List<MedicalReport>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);
        Task<List<MedicalReport>> GetPatientMedicalReportsWithDetailsAsync(int patientId);
        Task<List<MedicalReport>> GetPatientMedicalHistoryAsync(int patientId);
        Task<object> GetReportStatisticsAsync();
    }
}