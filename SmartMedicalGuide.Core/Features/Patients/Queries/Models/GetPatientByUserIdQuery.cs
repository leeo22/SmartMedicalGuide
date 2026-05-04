using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Patients.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Models
{
    public class GetPatientByUserIdQuery : IRequest<Response<GetSinglePatientResponse>>
    {
        public int UserId { get; set; }
        public GetPatientByUserIdQuery(int userId) => UserId = userId;
    }
}