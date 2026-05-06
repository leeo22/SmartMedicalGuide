using SmartMedicalGuide.Core.Features.Wallets.Queries.Results;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Wallets
{
    public partial class WalletProfile
    {
        public void GetWalletListResponseMapping()
        {
            CreateMap<Wallet, GetWalletListResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.UserName : null))
                .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User != null ? src.User.FullName : null));
        }
    }
}