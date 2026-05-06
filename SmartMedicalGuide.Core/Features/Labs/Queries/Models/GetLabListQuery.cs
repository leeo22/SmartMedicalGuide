using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Labs.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Labs.Queries.Models
{
    public class GetLabListQuery : IRequest<Response<List<GetLabListResponse>>>
    {
        public string? Location { get; set; }
        public string? SearchKeyword { get; set; }
        public bool? IsVerified { get; set; }
        public int? ServiceId { get; set; }
    }
}