using Microsoft.AspNetCore.Http;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IAttachmentServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<Attachment>> GetListAsync();
        Task<Attachment?> GetByIDAsync(int id);
        Task<string> AddAsync(Attachment attachment);
        Task<string> EditAsync(Attachment attachment);
        Task<string> DeleteAsync(Attachment attachment);
        #endregion

        #region Additional Important Functions - 7 Functions
        Task<List<Attachment>> GetByUserIdAsync(int userId);
        Task<List<Attachment>> GetByEntityAsync(string entityType, int entityId);
        Task<(string filePath, string fileName, string contentType)> DownloadFileAsync(int attachmentId);
        Task<string> UploadFileAsync(int userId, IFormFile file, string? entityType = null, int? entityId = null, string? description = null);
        Task<string> DeleteFileAsync(int attachmentId);
        Task<string> UpdateFileAsync(int attachmentId, IFormFile newFile);
        Task<long> GetTotalFileSizeByUserAsync(int userId);
        Task<List<Attachment>> GetByUserIdAndEntityAsync(int userId, string entityType, int? entityId = null);
        #endregion
    }
}