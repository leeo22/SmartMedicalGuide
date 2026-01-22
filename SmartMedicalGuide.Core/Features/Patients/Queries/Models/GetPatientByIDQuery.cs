using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Patients.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Models
{
    public class GetPatientByIDQuery : IRequest<Response<GetSinglePatientResponse>>
    {
        public int Id { get; set; }
        public GetPatientByIDQuery(int id)
        {
            Id = id;
        }
    }
}
