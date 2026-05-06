using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Reviews.Queries.Models;
using SmartMedicalGuide.Core.Features.Reviews.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Reviews.Queries.Handlers
{
    public class ReviewQueryHandler : ResponseHandler,
        IRequestHandler<GetReviewListQuery, Response<List<GetReviewListResponse>>>,
        IRequestHandler<GetReviewByIdQuery, Response<GetSingleReviewResponse>>,
        IRequestHandler<GetAverageRatingQuery, Response<double>>,
        IRequestHandler<GetRatingDistributionQuery, Response<object>>,
        IRequestHandler<GetRecentReviewsQuery, Response<List<GetReviewListResponse>>>,
        IRequestHandler<CheckPatientReviewedQuery, Response<bool>>,
        IRequestHandler<GetReviewStatisticsQuery, Response<object>>
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
            List<Review> reviews;

            if (!string.IsNullOrWhiteSpace(request.TargetType) && request.TargetId.HasValue)
            {
                reviews = await _reviewServices.GetByTargetAsync(request.TargetType, request.TargetId.Value);
            }
            else if (request.PatientId.HasValue)
            {
                reviews = await _reviewServices.GetByPatientIdAsync(request.PatientId.Value);
            }
            else
            {
                reviews = await _reviewServices.GetListAsync();
            }

            if (request.MinRating.HasValue)
            {
                reviews = reviews.Where(x => x.Rating >= request.MinRating.Value).ToList();
            }
            if (request.MaxRating.HasValue)
            {
                reviews = reviews.Where(x => x.Rating <= request.MaxRating.Value).ToList();
            }

            var result = _mapper.Map<List<GetReviewListResponse>>(reviews);
            return Success(result);
        }

        public async Task<Response<GetSingleReviewResponse>> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _reviewServices.GetByIDAsync(request.Id);
            if (review == null)
                return NotFound<GetSingleReviewResponse>("Review not found");

            var result = _mapper.Map<GetSingleReviewResponse>(review);
            return Success(result);
        }

        public async Task<Response<double>> Handle(GetAverageRatingQuery request, CancellationToken cancellationToken)
        {
            var average = await _reviewServices.GetAverageRatingAsync(request.TargetType, request.TargetId);
            return Success(Math.Round(average, 1));
        }

        public async Task<Response<object>> Handle(GetRatingDistributionQuery request, CancellationToken cancellationToken)
        {
            var distribution = await _reviewServices.GetRatingDistributionAsync(request.TargetType, request.TargetId);
            return Success(distribution);
        }

        public async Task<Response<List<GetReviewListResponse>>> Handle(GetRecentReviewsQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _reviewServices.GetRecentReviewsAsync(request.TargetType, request.TargetId, request.Page, request.PageSize);
            var result = _mapper.Map<List<GetReviewListResponse>>(reviews);
            return Success(result);
        }

        public async Task<Response<bool>> Handle(CheckPatientReviewedQuery request, CancellationToken cancellationToken)
        {
            var reviewed = await _reviewServices.CheckPatientReviewedAsync(request.PatientId, request.TargetType, request.TargetId);
            return Success(reviewed);
        }

        public async Task<Response<object>> Handle(GetReviewStatisticsQuery request, CancellationToken cancellationToken)
        {
            var statistics = await _reviewServices.GetReviewStatisticsAsync();
            return Success(statistics);
        }
    }
}