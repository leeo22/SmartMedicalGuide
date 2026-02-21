using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class LabServices : ILabServices
    {

        #region Fields
        private readonly ILabRepository _labRepository;

        #endregion

        #region Constructors
        public LabServices(ILabRepository labRepository)
        {
            _labRepository = labRepository;
        }


        #endregion

        #region Handels Functions
        public async Task<string> AddAsync(Lab lab)
        {
            await _labRepository.AddAsync(lab);
            return "Success";
        }

        public async Task<string> DeleteAsync(Lab lab)
        {
            var trans = _labRepository.BeginTransaction();
            try
            {
                await _labRepository.DeleteAsync(lab);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }
        }

        public async Task<string> EditAsync(Lab lab)
        {
            await _labRepository.UpdateAsync(lab);
            return "Success";
        }

        public async Task<Lab> GetLabByIdAsync(int id)
        {
            var lab = _labRepository.GetByIdAsync()
                                      .Include(x => x.User)
                                      .ThenInclude(r => r.Role)
                                      .Where(x => x.LabId.Equals(id))
                                      .FirstOrDefault();
            return lab;
        }

        public async Task<List<Lab>> GetLabsListAsync()
        {
            return await _labRepository.GetLabsListAsync();
        }
        #endregion
    }
}
