using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Specializations.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Specializations.Queries.Models
{
    public class GetSpecializationWithDetailsQuery : IRequest<Response<GetSpecializationWithDetailsResponse>>
    {
        public int Id { get; set; }
        public GetSpecializationWithDetailsQuery(int id) => Id = id;
    }
}