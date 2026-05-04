using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Specializations.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Specializations.Queries.Models
{
    public class GetPopularSpecializationsQuery : IRequest<Response<List<GetSpecializationListResponse>>>
    {
        public int Limit { get; set; } = 10;
    }
}