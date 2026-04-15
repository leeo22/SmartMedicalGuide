using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IReportServices
    {
        public Task<List<Report>> GetListAsync();
        public Task<Report> GetByIDAsync(int id);
        public Task<string> AddAsync(Report report);
        public Task<string> EditAsync(Report report);
        public Task<string> DeleteAsync(Report report);

    }
}
