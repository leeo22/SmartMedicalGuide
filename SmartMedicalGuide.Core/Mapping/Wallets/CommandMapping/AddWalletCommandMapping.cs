using SmartMedicalGuide.Core.Features.Wallets.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Wallets
{
    public partial class WalletProfile
    {
        public void AddWalletCommandMapping()
        {
            CreateMap<AddWalletCommand, Wallet>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.DoctorAccountNumber, opt => opt.MapFrom(src => src.DoctorAccountNumber))
                .ForMember(dest => dest.AccountHolderName, opt => opt.MapFrom(src => src.AccountHolderName))
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.BankName))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency ?? "SAR"));
        }
    }
}