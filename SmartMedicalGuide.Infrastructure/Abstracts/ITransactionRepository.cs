using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface ITransactionRepository : IGenericRepositoryAsync<Transaction>
    {
        Task<Transaction?> GetTransactionByIdWithIncludesAsync(int id);
        Task<List<Transaction>> GetAllTransactionsWithIncludesAsync();
        Task<List<Transaction>> GetByWalletIdAsync(int walletId);
        Task<List<Transaction>> GetByUserIdAsync(int userId);
        Task<List<Transaction>> GetByTypeAsync(string type);
        Task<List<Transaction>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);
        Task<decimal> GetWalletBalanceAsync(int walletId);
        Task<List<Transaction>> GetUserTransactionHistoryAsync(int userId);
        Task<object> GetTransactionStatisticsAsync();
        Task<List<Transaction>> GetRecentTransactionsAsync(int walletId, int limit);
        Task<decimal> GetTotalCreditByWalletAsync(int walletId);
        Task<decimal> GetTotalDebitByWalletAsync(int walletId);
    }
}