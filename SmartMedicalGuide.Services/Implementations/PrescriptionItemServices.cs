using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

namespace SmartMedicalGuide.Services.Abstracts
{
    public class PrescriptionItemServices : IPrescriptionItemServices
    {
        #region Fields
        private readonly IPrescriptionItemRepository _prescriptionItemRepository;
        #endregion

        #region Constructors
        public PrescriptionItemServices(IPrescriptionItemRepository prescriptionItemRepository)
        {
            _prescriptionItemRepository = prescriptionItemRepository;
        }
        #endregion

        #region Handlers Functions
        public async Task<string> AddAsync(PrescriptionItem prescriptionItem)
        {
            await _prescriptionItemRepository.AddAsync(prescriptionItem);
            return "Success";
        }

        public async Task<string> DeleteAsync(PrescriptionItem prescriptionItem)
        {
            var trans = _prescriptionItemRepository.BeginTransaction();
            try
            {
                await _prescriptionItemRepository.DeleteAsync(prescriptionItem);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(PrescriptionItem prescriptionItem)
        {
            await _prescriptionItemRepository.UpdateAsync(prescriptionItem);
            return "Success";
        }

        public async Task<PrescriptionItem> GetByIDAsync(int id)
        {
            var result = _prescriptionItemRepository.GetByIdAsync()
                                            .Where(x => x.ItemId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<List<PrescriptionItem>> GetByPrescriptionIdAsync(int prescriptionId)
        {
            return await _prescriptionItemRepository.GetTableAsTracking()
                .Where(x => x.PrescriptionId == prescriptionId)
                .ToListAsync();
        }

        public async Task<List<PrescriptionItem>> GetListAsync()
        {
            return await _prescriptionItemRepository.GetTableAsTracking().ToListAsync();
        }
        #endregion
    }
}