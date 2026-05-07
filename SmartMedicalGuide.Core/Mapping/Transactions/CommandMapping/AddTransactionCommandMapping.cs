using SmartMedicalGuide.Core.Features.Transactions.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Transactions
{
    public partial class TransactionProfile
    {
        public void AddTransactionCommandMapping()
        {
            CreateMap<AddTransactionCommand, Transaction>()
                .ForMember(dest => dest.WalletId, opt => opt.MapFrom(src => src.WalletId))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ReferenceId, opt => opt.MapFrom(src => src.ReferenceId))
                .ForMember(dest => dest.ReferenceType, opt => opt.MapFrom(src => src.ReferenceType))
                .ForMember(dest => dest.TransactionReference, opt => opt.MapFrom(src => src.TransactionReference));
        }
    }
}