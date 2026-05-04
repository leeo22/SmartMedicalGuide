using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorsByPriceRangeQuery : IRequest<Response<List<GetDoctorListResponse>>>
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}