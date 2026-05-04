using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Models
{
    public class SearchDoctorsQuery : IRequest<Response<List<GetDoctorListResponse>>>
    {
        public string Keyword { get; set; }
    }
}