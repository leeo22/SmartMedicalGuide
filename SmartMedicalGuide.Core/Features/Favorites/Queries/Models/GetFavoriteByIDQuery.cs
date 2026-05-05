using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Favorites.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Favorites.Queries.Models
{
    public class GetFavoriteByIdQuery : IRequest<Response<GetSingleFavoriteResponse>>
    {
        public int Id { get; set; }
        public GetFavoriteByIdQuery(int id) => Id = id;
    }
}