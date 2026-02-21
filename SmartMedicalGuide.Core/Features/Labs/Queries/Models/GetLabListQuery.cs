using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Labs.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Labs.Queries.Models
{
    public class GetLabListQuery : IRequest<Response<List<GetLabListRespones>>>
    {
    }
}
