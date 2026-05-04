using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorByIdQuery : IRequest<Response<GetSingleDoctorResponse>>
    {
        public int Id { get; set; }
        public GetDoctorByIdQuery(int id) => Id = id;
    }
}