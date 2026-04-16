using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface ITransactionServices
    {
        public Task<List<Transaction>> GetListAsync();
        public Task<Transaction> GetByIDAsync(int id);
        public Task<string> AddAsync(Transaction transaction);
        public Task<string> EditAsync(Transaction transaction);
        public Task<string> DeleteAsync(Transaction transaction);
        public Task<List<Transaction>> GetByWalletIdAsync(int walletId);
        public Task<decimal> GetTotalByWalletIdAsync(int walletId, string type);
    }
}