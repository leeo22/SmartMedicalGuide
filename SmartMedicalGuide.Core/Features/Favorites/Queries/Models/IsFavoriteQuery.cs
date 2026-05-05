using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Favorites.Queries.Models
{
    public class IsFavoriteQuery : IRequest<Response<bool>>
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}