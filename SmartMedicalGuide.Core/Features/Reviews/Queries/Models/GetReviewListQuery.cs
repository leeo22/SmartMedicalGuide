using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Reviews.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Reviews.Queries.Models
{
    public class GetReviewListQuery : IRequest<Response<List<GetReviewListResponse>>>
    {
        public int? PatientId { get; set; }
        public string? TargetType { get; set; }
        public int? TargetId { get; set; }
        public int? Rating { get; set; }
        public GetReviewListQuery() { }
        public GetReviewListQuery(int? patientId, string? targetType, int? targetId, int? rating)
        {
            PatientId = patientId;
            TargetType = targetType;
            TargetId = targetId;
            Rating = rating;
        }
    }
}