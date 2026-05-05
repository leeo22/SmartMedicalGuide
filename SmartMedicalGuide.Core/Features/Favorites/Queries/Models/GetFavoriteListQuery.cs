using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Favorites.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Favorites.Queries.Models
{
    public class GetFavoriteListQuery : IRequest<Response<List<GetFavoriteListResponse>>>
    {
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
    }
}