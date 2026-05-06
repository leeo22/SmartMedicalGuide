using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IAttachmentRepository : IGenericRepositoryAsync<Attachment>
    {
        Task<Attachment?> GetAttachmentByIdWithIncludesAsync(int id);
        Task<List<Attachment>> GetAllAttachmentsWithIncludesAsync();
        Task<List<Attachment>> GetByUserIdAsync(int userId);
        Task<List<Attachment>> GetByEntityAsync(string entityType, int entityId);
        Task<List<Attachment>> GetByUserIdAndEntityAsync(int userId, string entityType, int? entityId = null);
        Task<bool> DeleteAttachmentFileAsync(int attachmentId);

    }
}