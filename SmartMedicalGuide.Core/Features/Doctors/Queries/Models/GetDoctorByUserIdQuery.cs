using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorByUserIdQuery : IRequest<Response<GetSingleDoctorResponse>>
    {
        public int UserId { get; set; }
        public GetDoctorByUserIdQuery(int userId) => UserId = userId;
    }
}