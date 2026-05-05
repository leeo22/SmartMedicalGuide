using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Favorites.Commands.Models
{
    public class DeleteFavoriteCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteFavoriteCommand(int id) => Id = id;
    }
}