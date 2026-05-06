using SmartMedicalGuide.Core.Features.Wallets.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Wallets
{
    public partial class WalletProfile
    {
        public void EditWalletCommandMapping()
        {
            CreateMap<EditWalletCommand, Wallet>()
                .ForMember(dest => dest.WalletId, opt => opt.MapFrom(src => src.WalletId))
                .ForMember(dest => dest.DoctorAccountNumber, opt => opt.MapFrom(src => src.DoctorAccountNumber))
                .ForMember(dest => dest.AccountHolderName, opt => opt.MapFrom(src => src.AccountHolderName))
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.BankName))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}