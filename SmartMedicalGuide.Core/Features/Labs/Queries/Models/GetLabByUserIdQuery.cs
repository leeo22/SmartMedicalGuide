using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Labs.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Labs.Queries.Models
{
    public class GetLabByUserIdQuery : IRequest<Response<GetSingleLabResponse>>
    {
        public int UserId { get; set; }

        public GetLabByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}