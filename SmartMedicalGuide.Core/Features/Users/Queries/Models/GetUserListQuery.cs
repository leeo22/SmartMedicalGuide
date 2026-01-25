using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Users.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Users.Queries.Models
{
    public class GetUserListQuery : IRequest<Response<List<GetUserListResponse>>>
    {

    }
}
