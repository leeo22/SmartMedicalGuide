using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Patients.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Models
{
    public class GetPatientByIdQuery : IRequest<Response<GetSinglePatientResponse>>
    {
        public int Id { get; set; }
        public GetPatientByIdQuery(int id) => Id = id;
    }
}