using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Transactions
{
    public partial class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            AddTransactionCommandMapping();
            EditTransactionCommandMapping();
            GetTransactionListResponseMapping();
            GetSingleTransactionResponseMapping();
        }
    }
}