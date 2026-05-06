using SmartMedicalGuide.Core.Features.Wallets.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Wallets
{
    public partial class WalletProfile
    {
        public void GetSingleWalletResponseMapping()
        {
            CreateMap<Wallet, GetSingleWalletResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.UserName : null))
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User != null ? src.User.FullName : null))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User != null ? src.User.Email : null));
        }
    }
}