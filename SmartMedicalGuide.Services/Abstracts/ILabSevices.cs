using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface ILabServices
    {
        public Task<List<Lab>> GetLabsListAsync();
        public Task<Lab> GetLabByIdAsync(int id);
        public Task<string> AddAsync(Lab lab);
        public Task<string> EditAsync(Lab lab);
        public Task<string> DeleteAsync(Lab lab);
    }
}
