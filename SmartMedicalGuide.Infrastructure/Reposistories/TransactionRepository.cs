using Microsoft.EntityFrameworkCore;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.Abstracts;
using SmartMedicalGuide.Infrastructure.Context;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Reposistories
{
    public class TransactionRepository : GenericRepositoryAsync<Transaction>, ITransactionRepository
    {
        #region Fields
        private readonly DbSet<Transaction> _transaction;
        #endregion

        #region Constructors
        public TransactionRepository(MedicalGuideDbContext dBContext) : base(dBContext)
        {
            _transaction = dBContext.Set<Transaction>();

        }

        #endregion

        #region Handels Functions

        #endregion

    }
}
