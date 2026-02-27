using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorByNameQuery : IRequest<Response<GetDoctorNameResponse>>
    {
        public string Name { get; set; }
        public GetDoctorByNameQuery(string name)
        {
            Name = name;
        }
    }
}
