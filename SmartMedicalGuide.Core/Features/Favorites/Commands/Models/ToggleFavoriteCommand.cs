using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Favorites.Commands.Models
{
    public class ToggleFavoriteCommand : IRequest<Response<bool>>
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}