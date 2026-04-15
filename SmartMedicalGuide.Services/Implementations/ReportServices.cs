using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class ReportServices : IReportServices
    {
        #region Fields
        private readonly IReportRepository _reportRepository;
        #endregion
        #region Constructors
        public ReportServices(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }


        #endregion
        #region Handels Functions
        public async Task<string> AddAsync(Report report)
        {
            await _reportRepository.AddAsync(report);
            return "Success";
        }

        public async Task<string> DeleteAsync(Report report)
        {
            var trans = _reportRepository.BeginTransaction();
            try
            {
                await _reportRepository.DeleteAsync(report);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }
        }

        public async Task<string> EditAsync(Report report)
        {
            await _reportRepository.UpdateAsync(report);
            return "Success";
        }

        public async Task<Report> GetByIDAsync(int id)
        {
            var report = _reportRepository.GetByIdAsync()
                                            .Where(x => x.ReportId.Equals(id))
                                            .FirstOrDefault();
            return report;
        }

        public async Task<List<Report>> GetListAsync()
        {
            return await _reportRepository.GetAllListAsync();
        }
        #endregion
    }
}
