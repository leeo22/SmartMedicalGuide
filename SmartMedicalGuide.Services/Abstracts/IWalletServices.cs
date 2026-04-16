using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IWalletServices
    {
        public Task<List<Wallet>> GetListAsync();
        public Task<Wallet> GetByIDAsync(int id);
        public Task<string> AddAsync(Wallet wallet);
        public Task<string> EditAsync(Wallet wallet);
        public Task<string> DeleteAsync(Wallet wallet);
        public Task<Wallet> GetByUserIdAsync(int userId);
        public Task<decimal> GetBalanceByUserIdAsync(int userId);
    }
}