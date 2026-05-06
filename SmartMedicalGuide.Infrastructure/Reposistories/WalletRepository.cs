using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Repositories
{
    public class WalletRepository : GenericRepositoryAsync<Wallet>, IWalletRepository
    {
        #region Fields
        private readonly DbSet<Wallet> _wallets;
        #endregion

        #region Constructors
        public WalletRepository(MedicalGuideDbContext dbContext) : base(dbContext)
        {
            _wallets = dbContext.Set<Wallet>();
        }
        #endregion

        #region Basic Handlers
        public async Task<Wallet?> GetWalletByIdWithIncludesAsync(int id)
        {
            return await _wallets
                .Include(x => x.User)
                .Include(x => x.Transactions)
                .Where(x => !x.IsDeleted)
                .FirstOrDefaultAsync(x => x.WalletId == id);
        }

        public async Task<List<Wallet>> GetAllWalletsWithIncludesAsync()
        {
            return await _wallets
                .Include(x => x.User)
                .Include(x => x.Transactions)
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }
        #endregion

        #region Additional Handlers
        public async Task<Wallet?> GetByUserIdAsync(int userId)
        {
            return await _wallets
                .Include(x => x.User)
                .Include(x => x.Transactions)
                .Where(x => x.UserId == userId && !x.IsDeleted)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Wallet>> GetDoctorWalletsAsync()
        {
            return await _wallets
                .Include(x => x.User)
                .ThenInclude(u => u.Doctor)
                .Where(x => x.User.Doctor != null && !x.IsDeleted && x.IsActive)
                .ToListAsync();
        }

        public async Task<List<Wallet>> GetActiveWalletsAsync()
        {
            return await _wallets
                .Include(x => x.User)
                .Where(x => x.IsActive && !x.IsDeleted)
                .ToListAsync();
        }

        public async Task<bool> UpdateBalanceAsync(int walletId, decimal amount, bool isAddition)
        {
            try
            {
                var wallet = await _wallets.FirstOrDefaultAsync(x => x.WalletId == walletId && !x.IsDeleted);
                if (wallet == null)
                    return false;

                if (isAddition)
                {
                    wallet.AvailableBalance += amount;
                    wallet.TotalBalance += amount;
                }
                else
                {
                    if (wallet.AvailableBalance < amount)
                        return false;
                    wallet.AvailableBalance -= amount;
                    wallet.WithdrawnBalance += amount;
                }

                wallet.UpdatedAt = DateTime.UtcNow;
                await UpdateAsync(wallet);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TransferBetweenWalletsAsync(int fromWalletId, int toWalletId, decimal amount)
        {
            try
            {
                var fromWallet = await _wallets.FirstOrDefaultAsync(x => x.WalletId == fromWalletId && !x.IsDeleted);
                var toWallet = await _wallets.FirstOrDefaultAsync(x => x.WalletId == toWalletId && !x.IsDeleted);

                if (fromWallet == null || toWallet == null)
                    return false;

                if (fromWallet.AvailableBalance < amount)
                    return false;

                fromWallet.AvailableBalance -= amount;
                fromWallet.WithdrawnBalance += amount;
                fromWallet.UpdatedAt = DateTime.UtcNow;

                toWallet.AvailableBalance += amount;
                toWallet.TotalBalance += amount;
                toWallet.UpdatedAt = DateTime.UtcNow;

                await UpdateAsync(fromWallet);
                await UpdateAsync(toWallet);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}