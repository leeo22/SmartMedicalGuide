using SmartMedicalGuide.Core.Features.Transactions.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Transactions
{
    public partial class TransactionProfile
    {
        public void GetSingleTransactionResponseMapping()
        {
            CreateMap<Transaction, GetSingleTransactionResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Wallet != null && src.Wallet.User != null ? src.Wallet.User.FullName : null))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Wallet != null && src.Wallet.User != null ? src.Wallet.User.Email : null));
        }
    }
}