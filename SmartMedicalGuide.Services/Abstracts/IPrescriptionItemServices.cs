using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IPrescriptionItemServices
    {
        public Task<List<PrescriptionItem>> GetListAsync();
        public Task<PrescriptionItem> GetByIDAsync(int id);
        public Task<string> AddAsync(PrescriptionItem prescriptionItem);
        public Task<string> EditAsync(PrescriptionItem prescriptionItem);
        public Task<string> DeleteAsync(PrescriptionItem prescriptionItem);
        public Task<List<PrescriptionItem>> GetByPrescriptionIdAsync(int prescriptionId);
    }
}