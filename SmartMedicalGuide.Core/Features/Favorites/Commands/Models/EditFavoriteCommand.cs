using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Favorites.Commands.Models
{
    public class EditFavoriteCommand : IRequest<Response<string>>
    {
        public int FavoriteId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}