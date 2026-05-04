using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Specializations.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Specializations.Queries.Models
{
    public class GetSpecializationByNameQuery : IRequest<Response<GetSingleSpecializationResponse>>
    {
        public string Name { get; set; }
    }
}