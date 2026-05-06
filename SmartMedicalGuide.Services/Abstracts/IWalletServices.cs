using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Services.Abstracts
{
    public interface IWalletServices
    {
        #region Basic CRUD - 5 Functions
        Task<List<Wallet>> GetListAsync();
        Task<Wallet?> GetByIDAsync(int id);
        Task<string> AddAsync(Wallet wallet);
        Task<string> EditAsync(Wallet wallet);
        Task<string> DeleteAsync(Wallet wallet);
        #endregion

        #region Additional Important Functions - 6 Functions
        Task<Wallet?> GetByUserIdAsync(int userId);
        Task<List<Wallet>> GetDoctorWalletsAsync();
        Task<List<Wallet>> GetActiveWalletsAsync();
        Task<bool> UpdateBalanceAsync(int walletId, decimal amount, bool isAddition);
        Task<bool> TransferBetweenWalletsAsync(int fromWalletId, int toWalletId, decimal amount);
        Task<object> GetWalletStatisticsAsync();
        #endregion
    }
}