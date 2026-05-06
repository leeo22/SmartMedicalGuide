using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Reviews.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Reviews.Queries.Models
{
    public class GetReviewByIdQuery : IRequest<Response<GetSingleReviewResponse>>
    {
        public int Id { get; set; }
        public GetReviewByIdQuery(int id) => Id = id;
    }
}