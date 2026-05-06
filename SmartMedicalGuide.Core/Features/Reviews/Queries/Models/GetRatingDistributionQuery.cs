using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Reviews.Queries.Models
{
    public class GetRatingDistributionQuery : IRequest<Response<object>>
    {
        public string TargetType { get; set; }
        public int TargetId { get; set; }
    }
}