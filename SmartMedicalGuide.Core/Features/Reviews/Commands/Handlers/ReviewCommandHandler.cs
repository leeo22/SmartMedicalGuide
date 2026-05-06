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
            var review = _mapper.Map<Review>(request);
            var result = await _reviewServices.AddAsync(review);

            if (result == "Patient has already reviewed this target")
                return BadRequest<string>("You have already reviewed this doctor/lab");
            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Review added successfully");
        }

        public async Task<Response<string>> Handle(EditReviewCommand request, CancellationToken cancellationToken)
        {
            var review = _mapper.Map<Review>(request);
            var result = await _reviewServices.EditAsync(review);

            if (result == "Review not found")
                return NotFound<string>("Review not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Review edited successfully");
        }

        public async Task<Response<string>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _reviewServices.GetByIDAsync(request.Id);
            if (review == null)
                return NotFound<string>("Review not found");

            var result = await _reviewServices.DeleteAsync(review);
            return result == "Success" ? Deleted<string>("Review deleted successfully") : BadRequest<string>(result);
        }
    }
}