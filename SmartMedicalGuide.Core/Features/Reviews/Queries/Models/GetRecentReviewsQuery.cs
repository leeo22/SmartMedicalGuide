using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Reviews.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Reviews.Queries.Models
{
    public class GetRecentReviewsQuery : IRequest<Response<List<GetReviewListResponse>>>
    {
        public string TargetType { get; set; }
        public int TargetId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}