using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Labs.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Labs.Queries.Models
{
    public class GetLabWithServicesQuery : IRequest<Response<GetLabWithServicesResponse>>
    {
        public int Id { get; set; }
        public GetLabWithServicesQuery(int id) => Id = id;
    }
}