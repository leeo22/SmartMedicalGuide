using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class AttachmentRepository : GenericRepositoryAsync<Attachment>, IAttachmentRepository
    {
        #region Fields
        private readonly DbSet<Attachment> _attachments;
        #endregion

        #region Constructors
        public AttachmentRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _attachments = dbContext.Set<Attachment>();
        }
        #endregion

        #region Basic Handlers
        public async Task<Attachment?> GetAttachmentByIdWithIncludesAsync(int id)
        {
            return await _attachments
                .Include(x => x.User)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.AttachmentId == id);
        }

        public async Task<List<Attachment>> GetAllAttachmentsWithIncludesAsync()
        {
            return await _attachments
                .Include(x => x.User)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.UploadedAt)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<List<Attachment>> GetByUserIdAsync(int userId)
        {
            return await _attachments
                .Include(x => x.User)
                .Where(x => x.UserId == userId && !x.IsDeleted)
                .OrderByDescending(x => x.UploadedAt)
                .ToListAsync();
        }

        public async Task<List<Attachment>> GetByEntityAsync(string entityType, int entityId)
        {
            return await _attachments
                .Include(x => x.User)
                .Where(x => x.RelatedEntityType == entityType && x.RelatedEntityId == entityId && !x.IsDeleted)
                .OrderByDescending(x => x.UploadedAt)
                .ToListAsync();
        }

        public async Task<List<Attachment>> GetByUserIdAndEntityAsync(int userId, string entityType, int? entityId = null)
        {
            var query = _attachments
                .Include(x => x.User)
                .Where(x => x.UserId == userId && x.RelatedEntityType == entityType && !x.IsDeleted);

            if (entityId.HasValue)
            {
                query = query.Where(x => x.RelatedEntityId == entityId.Value);
            }

            return await query
                .OrderByDescending(x => x.UploadedAt)
                .ToListAsync();
        }

        public async Task<bool> DeleteAttachmentFileAsync(int attachmentId)
        {
            try
            {
                var attachment = await _attachments
                    .FirstOrDefaultAsync(x => x.AttachmentId == attachmentId && !x.IsDeleted);

                if (attachment == null)
                    return false;

                attachment.IsDeleted = true;
                await UpdateAsync(attachment);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}