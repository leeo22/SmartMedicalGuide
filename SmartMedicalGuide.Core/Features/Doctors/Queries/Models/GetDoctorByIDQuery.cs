using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorByIDQuery : IRequest<Response<GetSingleDoctorResponse>>
    {
        public int Id { get; set; }
        public GetDoctorByIDQuery(int id)
        {
            Id = id;
        }
    }
}
