using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Favorites.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Favorites.Queries.Models
{
    public class GetFavoriteDoctorsWithDetailsQuery : IRequest<Response<List<FavoriteDoctorDto>>>
    {
        public int PatientId { get; set; }
    }
}