using FluentValidation;
using SmartMedicalGuide.Core.Features.Reviews.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Reviews.Commands.Validators
{
    public class EditReviewValidator : AbstractValidator<EditReviewCommand>
    {
        private readonly IReviewServices _reviewServices;

        public EditReviewValidator(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.ReviewId)
                .GreaterThan(0).WithMessage("ReviewId must be greater than 0");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5");

            RuleFor(x => x.Comment)
                .MaximumLength(2000).WithMessage("Comment cannot exceed 2000 characters");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.ReviewId)
                .MustAsync(async (reviewId, cancellationToken) =>
                {
                    var review = await _reviewServices.GetByIDAsync(reviewId);
                    return review != null && !review.IsDeleted;
                })
                .WithMessage("Review does not exist");
        }
    }
}