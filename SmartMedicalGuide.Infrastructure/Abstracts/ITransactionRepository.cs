using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Infrastructure.InfrastuctureBases;

namespace SmartMedicalGuide.Infrastructure.Abstracts
{
    public interface ITransactionRepository : IGenericRepositoryAsync<Transaction>
    {
        //public Task<List<Transaction>> GetTransactionsListAsync();
    }
}
