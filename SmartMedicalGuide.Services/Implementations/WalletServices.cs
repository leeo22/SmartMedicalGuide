using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;

namespace SmartMedicalGuide.Services.Abstracts
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

        #region Handlers Functions
        public async Task<string> AddAsync(Wallet wallet)
        {
            await _walletRepository.AddAsync(wallet);
            return "Success";
        }

        public async Task<string> DeleteAsync(Wallet wallet)
        {
            var trans = _walletRepository.BeginTransaction();
            try
            {
                await _walletRepository.DeleteAsync(wallet);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        public async Task<string> EditAsync(Wallet wallet)
        {
            await _walletRepository.UpdateAsync(wallet);
            return "Success";
        }

        public async Task<decimal> GetBalanceByUserIdAsync(int userId)
        {
            var wallet = await GetByUserIdAsync(userId);
            return wallet?.Balance ?? 0;
        }

        public async Task<Wallet> GetByIDAsync(int id)
        {
            var result = _walletRepository.GetByIdAsync()
                                            .Where(x => x.WalletId == id)
                                            .FirstOrDefault();
            return result;
        }

        public async Task<Wallet> GetByUserIdAsync(int userId)
        {
            return await _walletRepository.GetTableAsTracking()
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Wallet>> GetListAsync()
        {
            return await _walletRepository.GetTableAsTracking().ToListAsync();
        }
        #endregion
    }
}