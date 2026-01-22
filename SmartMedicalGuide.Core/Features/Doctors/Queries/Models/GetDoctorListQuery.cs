using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorListQuery : IRequest<Response<List<GetDoctorListRespones>>>
    {
    }
}
