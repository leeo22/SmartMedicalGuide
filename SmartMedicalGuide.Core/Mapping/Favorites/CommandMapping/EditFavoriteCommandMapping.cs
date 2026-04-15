using SmartMedicalGuide.Core.Features.Favorites.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Favorites
{
    public partial class FavoriteProfile
    {
        public void EditFavoriteCommandMapping()
        {
            CreateMap<EditFavoriteCommand, Favorite>()
                .ForMember(dest => dest.FavoriteId, opt => opt.MapFrom(src => src.FavoriteId))
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId));
        }
    }
}