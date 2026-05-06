using FluentValidation;
using SmartMedicalGuide.Core.Features.LabServices.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.LabServices.Commands.Validators
{
    public class AddLabServiceValidator : AbstractValidator<AddLabServiceCommand>
    {
        private readonly ILabServices _labServices;

        public AddLabServiceValidator(ILabServices labServices)
        {
            _labServices = labServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.LabId)
                .GreaterThan(0).WithMessage("LabId must be greater than 0");

            RuleFor(x => x.ServiceName)
                .NotEmpty().WithMessage("Service name is required")
                .MaximumLength(200).WithMessage("Service name cannot exceed 200 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Description cannot exceed 2000 characters");

            RuleFor(x => x.Category)
                .MaximumLength(100).WithMessage("Category cannot exceed 100 characters");

            RuleFor(x => x.Duration)
                .GreaterThan(0).When(x => x.Duration.HasValue)
                .WithMessage("Duration must be greater than 0")
                .LessThanOrEqualTo(480).When(x => x.Duration.HasValue)
                .WithMessage("Duration cannot exceed 480 minutes (8 hours)");

            RuleFor(x => x.DiscountPercentage)
                .InclusiveBetween(0, 100).When(x => x.DiscountPercentage.HasValue)
                .WithMessage("Discount percentage must be between 0 and 100");

            RuleFor(x => x.ImageUrl)
                .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.ImageUrl))
                .WithMessage("Image URL cannot exceed 500 characters");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.LabId)
                .MustAsync(async (labId, cancellationToken) =>
                {
                    var lab = await _labServices.GetByIDAsync(labId);
                    return lab != null;
                })
                .WithMessage("Lab does not exist");
        }
    }
}