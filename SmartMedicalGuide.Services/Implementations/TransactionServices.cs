using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
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

        #region Basic CRUD Handlers
        public async Task<List<Transaction>> GetListAsync()
        {
            try
            {
                return await _transactionRepository.GetAllTransactionsWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting transactions list: {ex.Message}", ex);
            }
        }

        public async Task<Transaction?> GetByIDAsync(int id)
        {
            try
            {
                return await _transactionRepository.GetTransactionByIdWithIncludesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting transaction by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(Transaction transaction)
        {
            try
            {
                transaction.IsDeleted = false;
                transaction.CreatedAt = DateTime.UtcNow;
                transaction.Status = transaction.Status ?? "Completed";

                await _transactionRepository.AddAsync(transaction);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add transaction: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(Transaction transaction)
        {
            try
            {
                var existing = await _transactionRepository.GetByIdAsync()
                    .FirstOrDefaultAsync(x => x.TransactionId == transaction.TransactionId && !x.IsDeleted);

                if (existing == null)
                    return "Transaction not found";

                existing.Amount = transaction.Amount;
                existing.Type = transaction.Type ?? existing.Type;
                existing.Description = transaction.Description ?? existing.Description;
                existing.Status = transaction.Status ?? existing.Status;
                existing.ReferenceId = transaction.ReferenceId ?? existing.ReferenceId;
                existing.ReferenceType = transaction.ReferenceType ?? existing.ReferenceType;
                existing.TransactionReference = transaction.TransactionReference ?? existing.TransactionReference;

                await _transactionRepository.UpdateAsync(existing);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit transaction: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(Transaction transaction)
        {
            try
            {
                transaction.IsDeleted = true;
                await _transactionRepository.UpdateAsync(transaction);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete transaction: {ex.Message}";
            }
        }
        #endregion

        #region Additional Important Functions
        public async Task<List<Transaction>> GetByWalletIdAsync(int walletId)
        {
            try
            {
                return await _transactionRepository.GetByWalletIdAsync(walletId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting transactions for wallet {walletId}: {ex.Message}", ex);
            }
        }

        public async Task<decimal> GetWalletBalanceAsync(int walletId)
        {
            try
            {
                return await _transactionRepository.GetWalletBalanceAsync(walletId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting wallet balance: {ex.Message}", ex);
            }
        }

        public async Task<List<Transaction>> GetUserTransactionHistoryAsync(int userId)
        {
            try
            {
                return await _transactionRepository.GetUserTransactionHistoryAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting transaction history for user {userId}: {ex.Message}", ex);
            }
        }

        public async Task<List<Transaction>> GetRecentTransactionsAsync(int walletId, int limit)
        {
            try
            {
                return await _transactionRepository.GetRecentTransactionsAsync(walletId, limit);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting recent transactions for wallet {walletId}: {ex.Message}", ex);
            }
        }

        public async Task<object> GetTransactionStatisticsAsync()
        {
            try
            {
                return await _transactionRepository.GetTransactionStatisticsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting transaction statistics: {ex.Message}", ex);
            }
        }
        #endregion
    }
}