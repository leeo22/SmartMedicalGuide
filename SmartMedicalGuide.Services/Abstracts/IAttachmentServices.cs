using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IAttachmentServices
    {
        public Task<List<Attachment>> GetListAsync();
        public Task<Attachment> GetByIDAsync(int id);
        public Task<string> AddAsync(Attachment attachment);
        public Task<string> EditAsync(Attachment attachment);
        public Task<string> DeleteAsync(Attachment attachment);
        //public Task<List<Attachment>> GetByUserIdAsync(int userId);
    }
}