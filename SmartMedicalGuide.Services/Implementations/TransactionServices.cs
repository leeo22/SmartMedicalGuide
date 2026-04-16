using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

namespace SmartMedicalGuide.Services.Abstracts
{
    public class TransactionServices : ITransactionServices
    {
        #region Fields
        private readonly ITransactionRepository _transactionRepository;
        #endregion

        #region Constructors
        public TransactionServices(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        #endregion

        #region Handlers Functions
        public async Task<string> AddAsync(Transaction transaction)
        {
            await _transactionRepository.AddAsync(transaction);
            return "Success";
        }

        public async Task<string> DeleteAsync(Transaction transaction)
        {
            var trans = _transactionRepository.BeginTransaction();
            try
            {
                await _transactionRepository.DeleteAsync(transaction);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(Transaction transaction)
        {
            await _transactionRepository.UpdateAsync(transaction);
            return "Success";
        }

        public async Task<Transaction> GetByIDAsync(int id)
        {
            var result = _transactionRepository.GetByIdAsync()
                                            .Where(x => x.TransactionId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<List<Transaction>> GetByWalletIdAsync(int walletId)
        {
            return await _transactionRepository.GetTableAsTracking()
                .Where(x => x.WalletId == walletId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetListAsync()
        {
            return await _transactionRepository.GetTableAsTracking().ToListAsync();
        }

        public async Task<decimal> GetTotalByWalletIdAsync(int walletId, string type)
        {
            return await _transactionRepository.GetTableAsTracking()
                .Where(x => x.WalletId == walletId && x.Type == type)
                .SumAsync(x => x.Amount);
        }
        #endregion
    }
}