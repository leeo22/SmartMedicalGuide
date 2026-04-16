using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Reviews.Queries.Models;
using SmartMedicalGuide.Core.Features.Reviews.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Reviews.Queries.Handlers
{
    public class ReviewQueryHandler : ResponseHandler,
        IRequestHandler<GetReviewListQuery, Response<List<GetReviewListResponse>>>,
        IRequestHandler<GetReviewByIDQuery, Response<GetSingleReviewResponse>>
    {
        private readonly IReviewServices _reviewServices;
        private readonly IMapper _mapper;

        public ReviewQueryHandler(IReviewServices reviewServices, IMapper mapper)
        {
            _reviewServices = reviewServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetReviewListResponse>>> Handle(GetReviewListQuery request, CancellationToken cancellationToken)
        {
            var resultList = await _reviewServices.GetListAsync();
            if (request.PatientId.HasValue)
                resultList = resultList.Where(r => r.PatientId == request.PatientId.Value).ToList();
            if (!string.IsNullOrEmpty(request.TargetType))
                resultList = resultList.Where(r => r.TargetType == request.TargetType).ToList();
            if (request.TargetId.HasValue)
                resultList = resultList.Where(r => r.TargetId == request.TargetId.Value).ToList();
            if (request.Rating.HasValue)
                resultList = resultList.Where(r => r.Rating == request.Rating.Value).ToList();
            var resultListMapper = _mapper.Map<List<GetReviewListResponse>>(resultList);
            return Success(resultListMapper);
        }

        public async Task<Response<GetSingleReviewResponse>> Handle(GetReviewByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _reviewServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<GetSingleReviewResponse>("No review found");
            var result1 = _mapper.Map<GetSingleReviewResponse>(result);
            return Success(result1);
        }
    }
}