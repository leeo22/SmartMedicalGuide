using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Wallets
{
    public partial class WalletProfile : Profile
    {
        public WalletProfile()
        {
            AddWalletCommandMapping();
            EditWalletCommandMapping();
            GetWalletListResponseMapping();
            GetSingleWalletResponseMapping();
        }
    }
}