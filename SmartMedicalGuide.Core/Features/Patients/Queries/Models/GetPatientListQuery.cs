using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Patients.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Patients.Queries.Models
{
    public class GetPatientListQuery : IRequest<Response<List<GetPatientListResponse>>>
    {

    }
}
