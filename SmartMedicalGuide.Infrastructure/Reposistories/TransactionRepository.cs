using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class TransactionRepository : GenericRepositoryAsync<Transaction>, ITransactionRepository
    {
        #region Fields
        private readonly DbSet<Transaction> _transactions;
        #endregion

        #region Constructors
        public TransactionRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _transactions = dbContext.Set<Transaction>();
        }
        #endregion

        #region Basic Handlers
        public async Task<Transaction?> GetTransactionByIdWithIncludesAsync(int id)
        {
            return await _transactions
                .Include(x => x.Wallet)
                    .ThenInclude(w => w.User)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.TransactionId == id);
        }

        public async Task<List<Transaction>> GetAllTransactionsWithIncludesAsync()
        {
            return await _transactions
                .Include(x => x.Wallet)
                    .ThenInclude(w => w.User)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<List<Transaction>> GetByWalletIdAsync(int walletId)
        {
            return await _transactions
                .Include(x => x.Wallet)
                    .ThenInclude(w => w.User)
                .Where(x => x.WalletId == walletId && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetByUserIdAsync(int userId)
        {
            return await _transactions
                .Include(x => x.Wallet)
                    .ThenInclude(w => w.User)
                .Where(x => x.Wallet.UserId == userId && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetByTypeAsync(string type)
        {
            return await _transactions
                .Include(x => x.Wallet)
                    .ThenInclude(w => w.User)
                .Where(x => x.Type == type && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            return await _transactions
                .Include(x => x.Wallet)
                    .ThenInclude(w => w.User)
                .Where(x => x.CreatedAt >= fromDate && x.CreatedAt <= toDate && !x.IsDeleted)
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<decimal> GetWalletBalanceAsync(int walletId)
        {
            var transactions = await _transactions
                .Where(x => x.WalletId == walletId && !x.IsDeleted && x.Status == "Completed")
                .ToListAsync();

            decimal credit = transactions.Where(x => x.Type == "Credit").Sum(x => x.Amount);
            decimal debit = transactions.Where(x => x.Type == "Debit").Sum(x => x.Amount);

            return credit - debit;
        }

        public async Task<List<Transaction>> GetUserTransactionHistoryAsync(int userId)
        {
            return await _transactions
                .Include(x => x.Wallet)
                    .ThenInclude(w => w.User)
                .Where(x => x.Wallet.UserId == userId && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<object> GetTransactionStatisticsAsync()
        {
            var transactions = await _transactions.Where(x => !x.IsDeleted).ToListAsync();

            return new
            {
                TotalTransactions = transactions.Count,
                TotalCredit = transactions.Where(x => x.Type == "Credit").Sum(x => x.Amount),
                TotalDebit = transactions.Where(x => x.Type == "Debit").Sum(x => x.Amount),
                PendingTransactions = transactions.Count(x => x.Status == "Pending"),
                CompletedTransactions = transactions.Count(x => x.Status == "Completed"),
                FailedTransactions = transactions.Count(x => x.Status == "Failed"),
                ByDate = transactions.GroupBy(x => x.CreatedAt.Date)
                    .Select(g => new { Date = g.Key, Count = g.Count(), TotalAmount = g.Sum(x => x.Amount) })
                    .OrderByDescending(x => x.Date)
                    .Take(30)
            };
        }

        public async Task<List<Transaction>> GetRecentTransactionsAsync(int walletId, int limit)
        {
            return await _transactions
                .Include(x => x.Wallet)
                    .ThenInclude(w => w.User)
                .Where(x => x.WalletId == walletId && !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalCreditByWalletAsync(int walletId)
        {
            return await _transactions
                .Where(x => x.WalletId == walletId && x.Type == "Credit" && !x.IsDeleted && x.Status == "Completed")
                .SumAsync(x => x.Amount);
        }

        public async Task<decimal> GetTotalDebitByWalletAsync(int walletId)
        {
            return await _transactions
                .Where(x => x.WalletId == walletId && x.Type == "Debit" && !x.IsDeleted && x.Status == "Completed")
                .SumAsync(x => x.Amount);
        }
        #endregion
    }
}