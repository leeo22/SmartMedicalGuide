using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class PrescriptionItemServices : IPrescriptionItemServices
    {
        #region Fields
        private readonly IPrescriptionItemRepository _itemRepository;
        #endregion

        #region Constructors
        public PrescriptionItemServices(IPrescriptionItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<PrescriptionItem>> GetListAsync()
        {
            try
            {
                return await _itemRepository.GetAllItemsWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting prescription items list: {ex.Message}", ex);
            }
        }

        public async Task<PrescriptionItem?> GetByIDAsync(int id)
        {
            try
            {
                return await _itemRepository.GetItemByIdWithIncludesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting prescription item by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(PrescriptionItem item)
        {
            try
            {
                item.IsDeleted = false;
                await _itemRepository.AddAsync(item);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add prescription item: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(PrescriptionItem item)
        {
            try
            {
                var existing = await _itemRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.ItemId == item.ItemId && !x.IsDeleted);

                if (existing == null)
                    return "Item not found";

                existing.MedicineName = item.MedicineName ?? existing.MedicineName;
                existing.Dosage = item.Dosage ?? existing.Dosage;
                existing.Duration = item.Duration ?? existing.Duration;
                existing.Frequency = item.Frequency ?? existing.Frequency;
                existing.Instructions = item.Instructions ?? existing.Instructions;
                existing.Quantity = item.Quantity ?? existing.Quantity;

                await _itemRepository.UpdateAsync(existing);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit prescription item: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(PrescriptionItem item)
        {
            try
            {
                item.IsDeleted = true;
                await _itemRepository.UpdateAsync(item);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete prescription item: {ex.Message}";
            }
        }
        #endregion

        #region Additional Important Functions
        public async Task<List<PrescriptionItem>> GetByPrescriptionIdAsync(int prescriptionId)
        {
            try
            {
                return await _itemRepository.GetByPrescriptionIdAsync(prescriptionId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting items for prescription {prescriptionId}: {ex.Message}", ex);
            }
        }

        public async Task<bool> BulkAddItemsAsync(List<PrescriptionItem> items)
        {
            try
            {
                return await _itemRepository.BulkAddItemsAsync(items);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error bulk adding items: {ex.Message}", ex);
            }
        }

        public async Task<List<PrescriptionItem>> GetPrescriptionItemsWithDetailsAsync(int prescriptionId)
        {
            try
            {
                return await _itemRepository.GetPrescriptionItemsWithDetailsAsync(prescriptionId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting items with details for prescription {prescriptionId}: {ex.Message}", ex);
            }
        }

        public async Task<List<PrescriptionItem>> GetByMedicineNameAsync(string medicineName)
        {
            try
            {
                return await _itemRepository.GetByMedicineNameAsync(medicineName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting items by medicine name {medicineName}: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateItemQuantityAsync(int itemId, int quantity)
        {
            try
            {
                return await _itemRepository.UpdateItemQuantityAsync(itemId, quantity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating item quantity: {ex.Message}", ex);
            }
        }
        #endregion
    }
}