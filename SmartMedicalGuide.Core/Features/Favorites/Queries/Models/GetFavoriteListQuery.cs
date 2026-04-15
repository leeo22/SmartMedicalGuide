using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Favorites.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Favorites.Queries.Models
{
    public class GetFavoriteListQuery : IRequest<Response<List<GetFavoriteListResponse>>>
    {
        // يمكن إضافة فلتر حسب PatientId
        public int? PatientId { get; set; }

        public GetFavoriteListQuery() { }

        public GetFavoriteListQuery(int? patientId)
        {
            PatientId = patientId;
        }
    }
}