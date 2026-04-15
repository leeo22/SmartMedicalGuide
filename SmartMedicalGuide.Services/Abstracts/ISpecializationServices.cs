using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface ISpecializationServices
    {
        public Task<List<Specialization>> GetListAsync();
        public Task<Specialization> GetByIDAsync(int id);
        public Task<string> AddAsync(Specialization specialization);
        public Task<string> EditAsync(Specialization specialization);
        public Task<string> DeleteAsync(Specialization specialization);
    }
}
