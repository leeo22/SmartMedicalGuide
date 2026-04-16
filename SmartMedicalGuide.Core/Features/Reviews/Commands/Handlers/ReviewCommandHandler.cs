using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Reviews.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Reviews.Commands.Handlers
{
    public class ReviewCommandHandler : ResponseHandler,
        IRequestHandler<AddReviewCommand, Response<string>>,
        IRequestHandler<EditReviewCommand, Response<string>>,
        IRequestHandler<DeleteReviewCommand, Response<string>>
    {
        private readonly IReviewServices _reviewServices;
        private readonly IMapper _mapper;

        public ReviewCommandHandler(IReviewServices reviewServices, IMapper mapper)
        {
            _reviewServices = reviewServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var resultMapper = _mapper.Map<Review>(request);
            var result = await _reviewServices.AddAsync(resultMapper);
            return result == "Success" ? Created("Review added successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditReviewCommand request, CancellationToken cancellationToken)
        {
            var result = await _reviewServices.GetByIDAsync(request.ReviewId);
            if (result == null) return NotFound<string>("Review not found");
            var resultMapper = _mapper.Map<Review>(request);
            var result1 = await _reviewServices.EditAsync(resultMapper);
            return result1 == "Success" ? Success("Review edited successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var result = await _reviewServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<string>("Review not found");
            var result1 = await _reviewServices.DeleteAsync(result);
            return result1 == "Success" ? Deleted<string>($"Review deleted successfully: {request.Id}") : BadRequest<string>();
        }
    }
}