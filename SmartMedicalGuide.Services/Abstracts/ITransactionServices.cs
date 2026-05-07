using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface ITransactionServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<Transaction>> GetListAsync();
        Task<Transaction?> GetByIDAsync(int id);
        Task<string> AddAsync(Transaction transaction);
        Task<string> EditAsync(Transaction transaction);
        Task<string> DeleteAsync(Transaction transaction);
        #endregion

        #region Additional Important Functions - 5 Functions
        Task<List<Transaction>> GetByWalletIdAsync(int walletId);
        Task<decimal> GetWalletBalanceAsync(int walletId);
        Task<List<Transaction>> GetUserTransactionHistoryAsync(int userId);
        Task<List<Transaction>> GetRecentTransactionsAsync(int walletId, int limit);
        Task<object> GetTransactionStatisticsAsync();
        #endregion
    }
}