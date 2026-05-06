using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class PrescriptionItemRepository : GenericRepositoryAsync<PrescriptionItem>, IPrescriptionItemRepository
    {
        #region Fields
        private readonly DbSet<PrescriptionItem> _items;
        #endregion

        #region Constructors
        public PrescriptionItemRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _items = dbContext.Set<PrescriptionItem>();
        }
        #endregion

        #region Basic Handlers
        public async Task<PrescriptionItem?> GetItemByIdWithIncludesAsync(int id)
        {
            return await _items
                .Include(x => x.Prescription)
                    .ThenInclude(p => p.Doctor)
                        .ThenInclude(d => d.User)
                .Include(x => x.Prescription)
                    .ThenInclude(p => p.Patient)
                        .ThenInclude(pat => pat.User)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.ItemId == id);
        }

        public async Task<List<PrescriptionItem>> GetAllItemsWithIncludesAsync()
        {
            return await _items
                .Include(x => x.Prescription)
                    .ThenInclude(p => p.Doctor)
                        .ThenInclude(d => d.User)
                .Include(x => x.Prescription)
                    .ThenInclude(p => p.Patient)
                        .ThenInclude(pat => pat.User)
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.MedicineName)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<List<PrescriptionItem>> GetByPrescriptionIdAsync(int prescriptionId)
        {
            return await _items
                .Where(x => x.PrescriptionId == prescriptionId && !x.IsDeleted)
                .OrderBy(x => x.MedicineName)
                .ToListAsync();
        }

        public async Task<List<PrescriptionItem>> GetByMedicineNameAsync(string medicineName)
        {
            return await _items
                .Include(x => x.Prescription)
                .Where(x => x.MedicineName.Contains(medicineName) && !x.IsDeleted)
                .OrderBy(x => x.MedicineName)
                .ToListAsync();
        }

        public async Task<List<PrescriptionItem>> GetPrescriptionItemsWithDetailsAsync(int prescriptionId)
        {
            return await _items
                .Include(x => x.Prescription)
                    .ThenInclude(p => p.Doctor)
                        .ThenInclude(d => d.User)
                .Include(x => x.Prescription)
                    .ThenInclude(p => p.Patient)
                        .ThenInclude(pat => pat.User)
                .Where(x => x.PrescriptionId == prescriptionId && !x.IsDeleted)
                .OrderBy(x => x.MedicineName)
                .ToListAsync();
        }

        public async Task<bool> BulkAddItemsAsync(List<PrescriptionItem> items)
        {
            try
            {
                foreach (var item in items)
                {
                    item.IsDeleted = false;
                }
                await _items.AddRangeAsync(items);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> BulkDeleteItemsAsync(List<int> itemIds)
        {
            try
            {
                var items = await _items.Where(x => itemIds.Contains(x.ItemId) && !x.IsDeleted).ToListAsync();
                foreach (var item in items)
                {
                    item.IsDeleted = true;
                }
                _dbContext.UpdateRange(items);  
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateItemQuantityAsync(int itemId, int quantity)
        {
            try
            {
                var item = await _items.FirstOrDefaultAsync(x => x.ItemId == itemId && !x.IsDeleted);
                if (item == null)
                    return false;

                item.Quantity = quantity;
                await UpdateAsync(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<decimal> GetPrescriptionTotalCostAsync(int prescriptionId)
        {
            // Note: This assumes you have a Price field in PrescriptionItem
            // If not, you may need to join with a Medicines table
            var items = await _items
                .Where(x => x.PrescriptionId == prescriptionId && !x.IsDeleted)
                .ToListAsync();

            // This is a placeholder - actual implementation depends on your schema
            return items.Sum(x => x.Quantity ?? 0 * 0); // Placeholder
        }

        public async Task<object> GetMedicineUsageStatisticsAsync()
        {
            var items = await _items.Where(x => !x.IsDeleted).ToListAsync();

            return new
            {
                TotalItems = items.Count,
                MostUsedMedicines = items.GroupBy(x => x.MedicineName)
                    .Select(g => new { MedicineName = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .Take(10),
                ByPrescription = items.GroupBy(x => x.PrescriptionId)
                    .Select(g => new { PrescriptionId = g.Key, Count = g.Count() })
            };
        }
        #endregion
    }
}