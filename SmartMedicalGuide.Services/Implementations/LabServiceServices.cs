using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class LabServiceServices : ILabServiceServices
    {

        #region Fields
        private readonly ILabServiceRepository _labRepository;

        #endregion

        #region Constructors
        public LabServiceServices(ILabServiceRepository labRepository)
        {
            _labRepository = labRepository;
        }


        #endregion

        #region Handels Functions
        public async Task<string> AddAsync(LabService labService)
        {
            await _labRepository.AddAsync(labService);
            return "Success";
        }

        public async Task<string> DeleteAsync(LabService labService)
        {
            var trans = _labRepository.BeginTransaction();
            try
            {
                await _labRepository.DeleteAsync(labService);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }
        }

        public async Task<string> EditAsync(LabService labService)
        {
            await _labRepository.UpdateAsync(labService);
            return "Success";
        }



        public async Task<LabService> GetLabByIDAsync(int id)
        {
            var lab = _labRepository.GetByIdAsync()
                                      .Where(x => x.ServiceId.Equals(id))
                                      .FirstOrDefault();
            return lab;
        }

        public async Task<List<LabService>> GetLabServicesListAsync()
        {
            return await _labRepository.GetLabServicesListAsync();
        }


        #endregion
    }
}
