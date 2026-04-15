using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Favorites.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Favorites.Queries.Models
{
    public class GetFavoriteByIDQuery : IRequest<Response<GetSingleFavoriteResponse>>
    {
        public int Id { get; set; }

        public GetFavoriteByIDQuery(int id)
        {
            Id = id;
        }
    }
}