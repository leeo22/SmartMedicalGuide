using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IPrescriptionItemServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<PrescriptionItem>> GetListAsync();
        Task<PrescriptionItem?> GetByIDAsync(int id);
        Task<string> AddAsync(PrescriptionItem item);
        Task<string> EditAsync(PrescriptionItem item);
        Task<string> DeleteAsync(PrescriptionItem item);
        #endregion

        #region Additional Important Functions - 5 Functions
        Task<List<PrescriptionItem>> GetByPrescriptionIdAsync(int prescriptionId);
        Task<bool> BulkAddItemsAsync(List<PrescriptionItem> items);
        Task<List<PrescriptionItem>> GetPrescriptionItemsWithDetailsAsync(int prescriptionId);
        Task<List<PrescriptionItem>> GetByMedicineNameAsync(string medicineName);
        Task<bool> UpdateItemQuantityAsync(int itemId, int quantity);
        #endregion
    }
}