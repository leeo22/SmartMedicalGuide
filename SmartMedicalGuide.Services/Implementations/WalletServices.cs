using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Services.Implementations
{
    public class WalletServices : IWalletServices
    {
        #region Fields
        private readonly IWalletRepository _walletRepository;
        #endregion

        #region Constructors
        public WalletServices(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        #endregion

        #region Basic CRUD Handlers
        public async Task<List<Wallet>> GetListAsync()
        {
            try
            {
                return await _walletRepository.GetAllWalletsWithIncludesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting wallets list: {ex.Message}", ex);
            }
        }

        public async Task<Wallet?> GetByIDAsync(int id)
        {
            try
            {
                return await _walletRepository.GetWalletByIdWithIncludesAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting wallet by ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<string> AddAsync(Wallet wallet)
        {
            try
            {
                var existing = await _walletRepository.GetByUserIdAsync(wallet.UserId);
                if (existing != null)
                    return "Wallet already exists for this user";

                wallet.CreatedAt = DateTime.UtcNow;
                wallet.IsDeleted = false;
                wallet.IsActive = true;
                wallet.AvailableBalance = 0;
                wallet.WithdrawnBalance = 0;
                wallet.TotalBalance = 0;

                await _walletRepository.AddAsync(wallet);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to add wallet: {ex.Message}";
            }
        }

        public async Task<string> EditAsync(Wallet wallet)
        {
            try
            {
                var existing = await _walletRepository.GetTableAsTracking()
                    .FirstOrDefaultAsync(x => x.WalletId == wallet.WalletId && !x.IsDeleted);

                if (existing == null)
                    return "Wallet not found";

                existing.DoctorAccountNumber = wallet.DoctorAccountNumber ?? existing.DoctorAccountNumber;
                existing.AccountHolderName = wallet.AccountHolderName ?? existing.AccountHolderName;
                existing.BankName = wallet.BankName ?? existing.BankName;
                existing.Currency = wallet.Currency ?? existing.Currency;
                existing.IsActive = wallet.IsActive;
                existing.UpdatedAt = DateTime.UtcNow;

                await _walletRepository.UpdateAsync(existing);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to edit wallet: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(Wallet wallet)
        {
            try
            {
                wallet.IsDeleted = true;
                await _walletRepository.UpdateAsync(wallet);
                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed to delete wallet: {ex.Message}";
            }
        }
        #endregion

        #region Additional Important Functions
        public async Task<Wallet?> GetByUserIdAsync(int userId)
        {
            try
            {
                return await _walletRepository.GetByUserIdAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting wallet for user {userId}: {ex.Message}", ex);
            }
        }

        public async Task<List<Wallet>> GetDoctorWalletsAsync()
        {
            try
            {
                return await _walletRepository.GetDoctorWalletsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting doctor wallets: {ex.Message}", ex);
            }
        }

        public async Task<List<Wallet>> GetActiveWalletsAsync()
        {
            try
            {
                return await _walletRepository.GetActiveWalletsAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting active wallets: {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateBalanceAsync(int walletId, decimal amount, bool isAddition)
        {
            try
            {
                return await _walletRepository.UpdateBalanceAsync(walletId, amount, isAddition);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating wallet balance: {ex.Message}", ex);
            }
        }

        public async Task<bool> TransferBetweenWalletsAsync(int fromWalletId, int toWalletId, decimal amount)
        {
            try
            {
                return await _walletRepository.TransferBetweenWalletsAsync(fromWalletId, toWalletId, amount);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error transferring between wallets: {ex.Message}", ex);
            }
        }

        public async Task<object> GetWalletStatisticsAsync()
        {
            try
            {
                var wallets = await _walletRepository.GetTableAsTracking()
                    .Where(x => !x.IsDeleted)
                    .ToListAsync();

                return new
                {
                    TotalWallets = wallets.Count,
                    TotalBalance = wallets.Sum(x => x.TotalBalance),
                    TotalAvailable = wallets.Sum(x => x.AvailableBalance),
                    TotalWithdrawn = wallets.Sum(x => x.WithdrawnBalance),
                    ActiveWallets = wallets.Count(x => x.IsActive),
                    AverageBalance = wallets.Any() ? wallets.Average(x => x.TotalBalance) : 0
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting wallet statistics: {ex.Message}", ex);
            }
        }
        #endregion
    }
}