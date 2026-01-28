using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Roles.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Roles.Queries.Models
{
    public class GetRoleByIDQuery : IRequest<Response<GetSingleRoleResponse>>
    {
        public int Id { get; set; }
        public GetRoleByIDQuery(int id)
        {
            Id = id;
        }

    }
}
