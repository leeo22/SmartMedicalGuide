using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorsBySpecializationQuery : IRequest<Response<List<GetDoctorListResponse>>>
    {
        public int SpecializationId { get; set; }
    }
}