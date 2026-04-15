using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Favorites.Commands.Models
{
    public class AddFavoriteCommand : IRequest<Response<string>>
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}