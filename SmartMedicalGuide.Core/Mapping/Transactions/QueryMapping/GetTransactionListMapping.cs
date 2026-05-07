using SmartMedicalGuide.Core.Features.Transactions.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Transactions
{
    public partial class TransactionProfile
    {
        public void GetTransactionListResponseMapping()
        {
            CreateMap<Transaction, GetTransactionListResponse>();
        }
    }
}