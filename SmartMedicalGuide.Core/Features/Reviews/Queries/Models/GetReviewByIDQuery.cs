using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Reviews.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Reviews.Queries.Models
{
    public class GetReviewByIDQuery : IRequest<Response<GetSingleReviewResponse>>
    {
        public int Id { get; set; }
        public GetReviewByIDQuery(int id) => Id = id;
    }
}