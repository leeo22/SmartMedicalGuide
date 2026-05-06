using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Reviews.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Reviews.Queries.Models
{
    public class GetReviewListQuery : IRequest<Response<List<GetReviewListResponse>>>
    {
        public string? TargetType { get; set; }
        public int? TargetId { get; set; }
        public int? PatientId { get; set; }
        public int? MinRating { get; set; }
        public int? MaxRating { get; set; }
    }
}