using FluentValidation;
using SmartMedicalGuide.Core.Features.LabServices.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.LabServices.Commands.Validators
{
    public class EditLabServiceValidator : AbstractValidator<EditLabServiceCommand>
    {
        private readonly ILabServiceServices _serviceServices;

        public EditLabServiceValidator(ILabServiceServices serviceServices)
        {
            _serviceServices = serviceServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.ServiceId)
                .GreaterThan(0).WithMessage("ServiceId must be greater than 0");

            RuleFor(x => x.ServiceName)
                .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.ServiceName))
                .WithMessage("Service name cannot exceed 200 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).When(x => x.Price.HasValue)
                .WithMessage("Price must be greater than 0");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Description cannot exceed 2000 characters");

            RuleFor(x => x.Duration)
                .GreaterThan(0).When(x => x.Duration.HasValue)
                .WithMessage("Duration must be greater than 0")
                .LessThanOrEqualTo(480).When(x => x.Duration.HasValue)
                .WithMessage("Duration cannot exceed 480 minutes (8 hours)");

            RuleFor(x => x.DiscountPercentage)
                .InclusiveBetween(0, 100).When(x => x.DiscountPercentage.HasValue)
                .WithMessage("Discount percentage must be between 0 and 100");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.ServiceId)
                .MustAsync(async (serviceId, cancellationToken) =>
                {
                    var service = await _serviceServices.GetByIDAsync(serviceId);
                    return service != null && !service.IsDeleted;
                })
                .WithMessage("Service does not exist");
        }
    }
}