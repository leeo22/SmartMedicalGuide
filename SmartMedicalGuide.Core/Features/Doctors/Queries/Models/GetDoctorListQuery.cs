using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Doctors.Queries.Models
{
    public class GetDoctorListQuery : IRequest<Response<List<GetDoctorListResponse>>>
    {
        public int? SpecializationId { get; set; }
        public bool? IsVerified { get; set; }
        public bool? IsAvailableForBooking { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? SearchKeyword { get; set; }
        public int? TopRatedLimit { get; set; }
        public string? Gender { get; set; }
    }
}