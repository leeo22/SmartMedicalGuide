using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Specializations.Queries.Models
{
    public class GetSpecializationStatisticsQuery : IRequest<Response<object>>
    {
        public int SpecializationId { get; set; }
        public GetSpecializationStatisticsQuery(int specializationId) => SpecializationId = specializationId;
    }
}