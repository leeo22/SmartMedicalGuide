using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Users.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Users.Queries.Models
{
    public class GetUserByIDQuery : IRequest<Response<GetSingleUserResponse>>
    {
        public int Id { get; set; }
        public GetUserByIDQuery(int id)
        {
            Id = id;
        }
    }
}
