using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class MedicalReportServices : IMedicalReportServices
    {
        #region Fields
        private readonly IMedicalReportRepository _reportRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string[] _allowedExtensions = { ".pdf", ".jpg", ".jpeg", ".png", ".doc", ".docx" };
        private readonly int _maxFileSize = 10 * 1024 * 1024; // 10MB
        #endregion

        #region Constructors
        public MedicalReportServices(IMedicalReportRepository reportRepository, IWebHostEnvironment webHostEnvironment)
        {
            _reportRepository = reportRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<MedicalReport>> GetListAsync()
        {
            try
            {
                return await _reportRepository.GetAllReportsWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting reports list: {ex.Message}", ex);
            }
        }

        public async Task<MedicalReport?> GetByIDAsync(int id)
        {
            try
            {
                return await _reportRepository.GetReportByIdWithIncludesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting report by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(MedicalReport report)
        {
            try
            {
                report.IsDeleted = false;
                report.CreatedAt = DateTime.UtcNow;
                report.ReportDate = report.ReportDate == default ? DateTime.UtcNow : report.ReportDate;

                await _reportRepository.AddAsync(report);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add report: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(MedicalReport report)
        {
            try
            {
                var existing = await _reportRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.ReportId == report.ReportId && !x.IsDeleted);

                if (existing == null)
                    return "Report not found";

                existing.ReportType = report.ReportType;
                existing.Description = report.Description;
                existing.ReportDate = report.ReportDate;

                await _reportRepository.UpdateAsync(existing);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit report: {ex.Message}";
            }
        }
        #endregion

        #region Additional Functions
        public async Task<List<MedicalReport>> GetByPatientIdAsync(int patientId)
        {
            try
            {
                return await _reportRepository.GetByPatientIdAsync(patientId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting reports for patient {patientId}: {ex.Message}", ex);
            }
        }

        public async Task<List<MedicalReport>> GetByDoctorIdAsync(int doctorId)
        {
            try
            {
                return await _reportRepository.GetByDoctorIdAsync(doctorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting reports for doctor {doctorId}: {ex.Message}", ex);
            }
        }

        public async Task<List<MedicalReport>> GetByReportTypeAsync(string reportType)
        {
            try
            {
                return await _reportRepository.GetByReportTypeAsync(reportType);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting reports by type {reportType}: {ex.Message}", ex);
            }
        }

        public async Task<List<MedicalReport>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            try
            {
                return await _reportRepository.GetByDateRangeAsync(fromDate, toDate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting reports by date range: {ex.Message}", ex);
            }
        }

        public async Task<List<MedicalReport>> GetPatientMedicalReportsWithDetailsAsync(int patientId)
        {
            try
            {
                return await _reportRepository.GetPatientMedicalReportsWithDetailsAsync(patientId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting detailed reports for patient {patientId}: {ex.Message}", ex);
            }
        }

        public async Task<List<MedicalReport>> GetPatientMedicalHistoryAsync(int patientId)
        {
            try
            {
                return await _reportRepository.GetPatientMedicalHistoryAsync(patientId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting medical history for patient {patientId}: {ex.Message}", ex);
            }
        }

        public async Task<object> GetReportStatisticsAsync()
        {
            try
            {
                return await _reportRepository.GetReportStatisticsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting report statistics: {ex.Message}", ex);
            }
        }
        #endregion

        #region File Operations
        public async Task<(string filePath, string fileName, string contentType)> DownloadReportFileAsync(int reportId)
        {
            try
            {
                var report = await _reportRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.ReportId == reportId && !x.IsDeleted);

                if (report == null)
                    throw new Exception("Report not found");

                if (string.IsNullOrEmpty(report.FilePath))
                    throw new Exception("No file attached to this report");

                var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, report.FilePath.TrimStart('/'));

                if (!File.Exists(fullPath))
                    throw new Exception("File not found on server");

                var fileName = Path.GetFileName(fullPath);
                var contentType = report.ContentType ?? "application/octet-stream";

                return (fullPath, fileName, contentType);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error downloading report file: {ex.Message}", ex);
            }
        }

        public async Task<string> UploadReportFileAsync(int reportId, IFormFile file)
        {
            try
            {
                var report = await _reportRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.ReportId == reportId && !x.IsDeleted);

                if (report == null)
                    return "Report not found";

                // Validate file
                if (file == null || file.Length == 0)
                    return "No file provided";

                if (file.Length > _maxFileSize)
                    return $"File size exceeds maximum allowed size of {_maxFileSize / (1024 * 1024)}MB";

                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!_allowedExtensions.Contains(extension))
                    return $"File type not allowed. Allowed types: {string.Join(", ", _allowedExtensions)}";

                // Delete old file if exists
                if (!string.IsNullOrEmpty(report.FilePath))
                {
                    var oldPath = Path.Combine(_webHostEnvironment.WebRootPath, report.FilePath.TrimStart('/'));
                    if (File.Exists(oldPath))
                        File.Delete(oldPath);
                }

                // Create directory if not exists
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "medical-reports");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                // Save new file
                var uniqueFileName = $"{Guid.NewGuid()}_{DateTime.Now.Ticks}{extension}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Update report
                report.FilePath = $"/uploads/medical-reports/{uniqueFileName}";
                report.FileSize = file.Length;
                report.ContentType = file.ContentType;

                await _reportRepository.UpdateAsync(report);

                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to upload file: {ex.Message}";
            }
        }

        public async Task<string> DeleteReportFileAsync(int reportId)
        {
            try
            {
                var report = await _reportRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.ReportId == reportId && !x.IsDeleted);

                if (report == null)
                    return "Report not found";

                if (string.IsNullOrEmpty(report.FilePath))
                    return "No file attached to this report";

                var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, report.FilePath.TrimStart('/'));
                if (File.Exists(fullPath))
                    File.Delete(fullPath);

                report.FilePath = null;
                report.FileSize = null;
                report.ContentType = null;

                await _reportRepository.UpdateAsync(report);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete file: {ex.Message}";
            }
        }

        public async Task<string> UpdateReportFileAsync(int reportId, IFormFile newFile)
        {
            try
            {
                var deleteResult = await DeleteReportFileAsync(reportId);
                if (deleteResult != "Success")
                    return deleteResult;

                return await UploadReportFileAsync(reportId, newFile);
            }
            catch (Exception ex)
            {
                return $"Failed to update file: {ex.Message}";
            }
        }
        #endregion
    }
}