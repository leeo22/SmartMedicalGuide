using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Clinics.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Clinics.Queries.Models
{
    public class GetClinicListQuery : IRequest<Response<List<GetClinicListResponse>>>
    {
        public int? DoctorId { get; set; }
        public string? Location { get; set; }
        public string? SearchKeyword { get; set; }
        public bool? IsActive { get; set; }
    }
}