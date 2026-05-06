using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface IWalletRepository : IGenericRepositoryAsync<Wallet>
    {
        Task<Wallet?> GetWalletByIdWithIncludesAsync(int id);
        Task<List<Wallet>> GetAllWalletsWithIncludesAsync();
        Task<Wallet?> GetByUserIdAsync(int userId);
        Task<List<Wallet>> GetDoctorWalletsAsync();
        Task<List<Wallet>> GetActiveWalletsAsync();
        Task<bool> UpdateBalanceAsync(int walletId, decimal amount, bool isAddition);
        Task<bool> TransferBetweenWalletsAsync(int fromWalletId, int toWalletId, decimal amount);
    }
}