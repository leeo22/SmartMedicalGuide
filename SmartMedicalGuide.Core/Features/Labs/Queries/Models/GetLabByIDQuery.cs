using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Labs.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Labs.Queries.Models
{
    public class GetLabByIDQuery : IRequest<Response<GetSingleLabResponse>>
    {
        public int Id { get; set; }
        public GetLabByIDQuery(int id)
        {
            Id = id;
        }
    }
}
