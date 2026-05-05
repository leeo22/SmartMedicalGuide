using AutoMapper;

namespace SmartMedicalGuide.Core.Mapping.Favorites
{
    public partial class FavoriteProfile : Profile
    {
        public FavoriteProfile()
        {
            AddFavoriteCommandMapping();
            GetFavoriteListResponseMapping();
            GetSingleFavoriteResponseMapping();
        }
    }
}