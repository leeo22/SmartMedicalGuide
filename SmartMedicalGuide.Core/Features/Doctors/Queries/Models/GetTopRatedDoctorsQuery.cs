using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Models
{
    public class GetTopRatedDoctorsQuery : IRequest<Response<List<GetDoctorListResponse>>>
    {
        public int Limit { get; set; } = 10;
    }
}