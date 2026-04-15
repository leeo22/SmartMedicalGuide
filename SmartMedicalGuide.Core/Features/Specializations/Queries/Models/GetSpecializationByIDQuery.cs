using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Specializations.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Specializations.Queries.Models
{
    public class GetSpecializationByIDQuery : IRequest<Response<GetSingleSpecializationResponse>>
    {
        public int Id { get; set; }
        public GetSpecializationByIDQuery(int id)
        {
            Id = id;
        }
    }
}
