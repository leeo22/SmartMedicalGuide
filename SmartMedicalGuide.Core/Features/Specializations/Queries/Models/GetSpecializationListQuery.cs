using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Specializations.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Specializations.Queries.Models
{
    public class GetSpecializationListQuery : IRequest<Response<List<GetSpecializationListResponse>>>
    {

    }
}
