using Microsoft.AspNetCore.Http;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IMedicalReportServices
    {
        #region Basic CRUD
        Task<List<MedicalReport>> GetListAsync();
        Task<MedicalReport?> GetByIDAsync(int id);
        Task<string> AddAsync(MedicalReport report);
        Task<string> EditAsync(MedicalReport report);
        #endregion

        #region Additional Functions
        Task<List<MedicalReport>> GetByPatientIdAsync(int patientId);
        Task<List<MedicalReport>> GetByDoctorIdAsync(int doctorId);
        Task<List<MedicalReport>> GetByReportTypeAsync(string reportType);
        Task<List<MedicalReport>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);
        Task<List<MedicalReport>> GetPatientMedicalReportsWithDetailsAsync(int patientId);
        Task<List<MedicalReport>> GetPatientMedicalHistoryAsync(int patientId);
        Task<object> GetReportStatisticsAsync();

        // File Operations
        Task<(string filePath, string fileName, string contentType)> DownloadReportFileAsync(int reportId);
        Task<string> UploadReportFileAsync(int reportId, IFormFile file);
        Task<string> DeleteReportFileAsync(int reportId);
        Task<string> UpdateReportFileAsync(int reportId, IFormFile newFile);
        #endregion
    }
}