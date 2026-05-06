using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IPrescriptionItemRepository : IGenericRepositoryAsync<PrescriptionItem>
    {
        Task<PrescriptionItem?> GetItemByIdWithIncludesAsync(int id);
        Task<List<PrescriptionItem>> GetAllItemsWithIncludesAsync();
        Task<List<PrescriptionItem>> GetByPrescriptionIdAsync(int prescriptionId);
        Task<List<PrescriptionItem>> GetByMedicineNameAsync(string medicineName);
        Task<List<PrescriptionItem>> GetPrescriptionItemsWithDetailsAsync(int prescriptionId);
        Task<bool> BulkAddItemsAsync(List<PrescriptionItem> items);
        Task<bool> BulkDeleteItemsAsync(List<int> itemIds);
        Task<bool> UpdateItemQuantityAsync(int itemId, int quantity);
        Task<decimal> GetPrescriptionTotalCostAsync(int prescriptionId);
        Task<object> GetMedicineUsageStatisticsAsync();
    }
}