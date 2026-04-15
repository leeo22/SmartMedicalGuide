using SmartMedicalGuide.Core.Features.Favorites.Commands.Models;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Mapping.Favorites
{
    public partial class FavoriteProfile
    {
        public void AddFavoriteCommandMapping()
        {
            CreateMap<AddFavoriteCommand, Favorite>()
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.PatientId))
                .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.DoctorId));
        }
    }
}