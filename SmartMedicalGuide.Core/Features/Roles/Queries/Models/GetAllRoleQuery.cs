using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Roles.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Roles.Queries.Models
{
    public class GetAllRoleQuery : IRequest<Response<List<GetRoleListResponse>>>
    {

    }
}
