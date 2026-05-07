using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class AttachmentServices : IAttachmentServices
    {
        #region Fields
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string[] _allowedExtensions = { ".pdf", ".jpg", ".jpeg", ".png", ".doc", ".docx", ".xls", ".xlsx", ".txt" };
        private readonly int _maxFileSize = 10 * 1024 * 1024; // 10MB
        #endregion

        #region Constructors
        public AttachmentServices(IAttachmentRepository attachmentRepository, IWebHostEnvironment webHostEnvironment)
        {
            _attachmentRepository = attachmentRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<Attachment>> GetListAsync()
        {
            try
            {
                return await _attachmentRepository.GetAllAttachmentsWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting attachments list: {ex.Message}", ex);
            }
        }

        public async Task<Attachment?> GetByIDAsync(int id)
        {
            try
            {
                return await _attachmentRepository.GetAttachmentByIdWithIncludesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting attachment by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(Attachment attachment)
        {
            try
            {
                attachment.IsDeleted = false;
                attachment.UploadedAt = DateTime.UtcNow;

                await _attachmentRepository.AddAsync(attachment);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add attachment: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(Attachment attachment)
        {
            try
            {
                var existing = await _attachmentRepository.GetTableAsTracking()
                    .FirstOrDefaultAsync(x => x.AttachmentId == attachment.AttachmentId && !x.IsDeleted);

                if (existing == null)
                    return "Attachment not found";

                existing.Description = attachment.Description ?? existing.Description;
                existing.RelatedEntityId = attachment.RelatedEntityId ?? existing.RelatedEntityId;
                existing.RelatedEntityType = attachment.RelatedEntityType ?? existing.RelatedEntityType;

                await _attachmentRepository.UpdateAsync(existing);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit attachment: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(Attachment attachment)
        {
            try
            {
                attachment.IsDeleted = true;
                await _attachmentRepository.UpdateAsync(attachment);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete attachment: {ex.Message}";
            }
        }
        #endregion

        #region Additional Important Functions
        public async Task<List<Attachment>> GetByUserIdAsync(int userId)
        {
            try
            {
                return await _attachmentRepository.GetByUserIdAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting attachments for user {userId}: {ex.Message}", ex);
            }
        }

        public async Task<List<Attachment>> GetByEntityAsync(string entityType, int entityId)
        {
            try
            {
                return await _attachmentRepository.GetByEntityAsync(entityType, entityId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting attachments for entity {entityType}/{entityId}: {ex.Message}", ex);
            }
        }

        public async Task<(string filePath, string fileName, string contentType)> DownloadFileAsync(int attachmentId)
        {
            try
            {
                var attachment = await _attachmentRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.AttachmentId == attachmentId && !x.IsDeleted);

                if (attachment == null)
                    throw new Exception("Attachment not found");

                if (string.IsNullOrEmpty(attachment.FilePath))
                    throw new Exception("File path not found");

                var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, attachment.FilePath.TrimStart('/'));

                if (!File.Exists(fullPath))
                    throw new Exception("File not found on server");

                return (fullPath, attachment.FileName ?? "download", attachment.ContentType ?? "application/octet-stream");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error downloading file: {ex.Message}", ex);
            }
        }

        public async Task<string> UploadFileAsync(int userId, IFormFile file, string? entityType = null, int? entityId = null, string? description = null)
        {
            try
            {
                // Validate file
                if (file == null || file.Length == 0)
                    return "No file provided";

                if (file.Length > _maxFileSize)
                    return $"File size exceeds maximum allowed size of {_maxFileSize / (1024 * 1024)}MB";

                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!_allowedExtensions.Contains(extension))
                    return $"File type not allowed. Allowed types: {string.Join(", ", _allowedExtensions)}";

                // Create directory if not exists
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "attachments");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                // Save file
                var uniqueFileName = $"{Guid.NewGuid()}_{DateTime.Now.Ticks}{extension}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Create attachment record
                var attachment = new Attachment
                {
                    UserId = userId,
                    FilePath = $"/uploads/attachments/{uniqueFileName}",
                    FileName = file.FileName,
                    FileSize = file.Length,
                    ContentType = file.ContentType,
                    RelatedEntityType = entityType,
                    RelatedEntityId = entityId,
                    Description = description,
                    UploadedAt = DateTime.UtcNow,
                    IsDeleted = false
                };

                await _attachmentRepository.AddAsync(attachment);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to upload file: {ex.Message}";
            }
        }

        public async Task<string> DeleteFileAsync(int attachmentId)
        {
            try
            {
                var attachment = await _attachmentRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.AttachmentId == attachmentId && !x.IsDeleted);

                if (attachment == null)
                    return "Attachment not found";

                if (!string.IsNullOrEmpty(attachment.FilePath))
                {
                    var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, attachment.FilePath.TrimStart('/'));
                    if (File.Exists(fullPath))
                        File.Delete(fullPath);
                }

                attachment.IsDeleted = true;
                await _attachmentRepository.UpdateAsync(attachment);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete file: {ex.Message}";
            }
        }

        public async Task<string> UpdateFileAsync(int attachmentId, IFormFile newFile)
        {
            try
            {
                var attachment = await _attachmentRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.AttachmentId == attachmentId && !x.IsDeleted);

                if (attachment == null)
                    return "Attachment not found";

                // Validate new file
                if (newFile == null || newFile.Length == 0)
                    return "No file provided";

                if (newFile.Length > _maxFileSize)
                    return $"File size exceeds maximum allowed size of {_maxFileSize / (1024 * 1024)}MB";

                var extension = Path.GetExtension(newFile.FileName).ToLowerInvariant();
                if (!_allowedExtensions.Contains(extension))
                    return $"File type not allowed. Allowed types: {string.Join(", ", _allowedExtensions)}";

                // Delete old file
                if (!string.IsNullOrEmpty(attachment.FilePath))
                {
                    var oldPath = Path.Combine(_webHostEnvironment.WebRootPath, attachment.FilePath.TrimStart('/'));
                    if (File.Exists(oldPath))
                        File.Delete(oldPath);
                }

                // Save new file
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", "attachments");
                var uniqueFileName = $"{Guid.NewGuid()}_{DateTime.Now.Ticks}{extension}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await newFile.CopyToAsync(stream);
                }

                // Update attachment record
                attachment.FilePath = $"/uploads/attachments/{uniqueFileName}";
                attachment.FileName = newFile.FileName;
                attachment.FileSize = newFile.Length;
                attachment.ContentType = newFile.ContentType;

                await _attachmentRepository.UpdateAsync(attachment);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to update file: {ex.Message}";
            }
        }

        public async Task<long> GetTotalFileSizeByUserAsync(int userId)
        {
            try
            {
                var attachments = await _attachmentRepository.GetTableAsTracking()
                    .Where(x => x.UserId == userId && !x.IsDeleted)
                    .ToListAsync();

                return attachments.Sum(x => x.FileSize ?? 0);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting total file size for user {userId}: {ex.Message}", ex);
            }
        }
        public async Task<List<Attachment>> GetByUserIdAndEntityAsync(int userId, string entityType, int? entityId = null)
        {
            try
            {
                return await _attachmentRepository.GetByUserIdAndEntityAsync(userId, entityType, entityId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting attachments for user {userId} and entity {entityType}/{entityId}: {ex.Message}", ex);
            }
        }
        #endregion
    }
}