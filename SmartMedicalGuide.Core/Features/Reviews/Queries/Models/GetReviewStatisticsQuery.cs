using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Reviews.Queries.Models
{
    public class GetReviewStatisticsQuery : IRequest<Response<object>>
    {
    }
}