using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

namespace SmartMedicalGuide.Services.Abstracts
{
    public class AttachmentServices : IAttachmentServices
    {
        #region Fields
        private readonly IAttachmentRepository _attachmentRepository;
        #endregion

        #region Constructors
        public AttachmentServices(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }
        #endregion

        #region Handlers Functions
        public async Task<string> AddAsync(Attachment attachment)
        {
            await _attachmentRepository.AddAsync(attachment);
            return "Success";
        }

        public async Task<string> DeleteAsync(Attachment attachment)
        {
            var trans = _attachmentRepository.BeginTransaction();
            try
            {
                await _attachmentRepository.DeleteAsync(attachment);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(Attachment attachment)
        {
            await _attachmentRepository.UpdateAsync(attachment);
            return "Success";
        }

        //public async Task<List<Attachment>> GetByUserIdAsync(int userId)
        //{
        //    return await _attachmentRepository.GetTableAsTracking()
        //        .Where(x => x.UserId == userId)
        //        .ToListAsync();
        //}

        public async Task<Attachment> GetByIDAsync(int id)
        {
            var result = _attachmentRepository.GetByIdAsync()
                                            .Where(x => x.AttachmentId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<List<Attachment>> GetListAsync()
        {
            return await _attachmentRepository.GetTableAsTracking().ToListAsync();
        }
        #endregion
    }
}