using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class WalletRepository : GenericRepositoryAsync<Wallet>, IWalletRepository
    {
        #region Fields
        private readonly DbSet<Wallet> _wallet;
        #endregion

        #region Constructors
        public WalletRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _wallet = dBContext.Set<Wallet>();

        }

        #endregion

        #region Handels Functions

        #endregion

    }
}
