using FluentValidation;
using SmartMedicalGuide.Core.Features.Labs.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Labs.Commands.Validators
{
    public class EditLabValidator : AbstractValidator<EditLabCommand>
    {
        private readonly ILabServices _labServices;

        public EditLabValidator(ILabServices labServices)
        {
            _labServices = labServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.LabId)
                .GreaterThan(0).WithMessage("LabId must be greater than 0");

            RuleFor(x => x.CenterName)
                .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.CenterName))
                .WithMessage("Center name cannot exceed 200 characters");

            RuleFor(x => x.Location)
                .MaximumLength(500).WithMessage("Location cannot exceed 500 characters");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("Invalid email format");

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90).When(x => x.Latitude.HasValue)
                .WithMessage("Latitude must be between -90 and 90");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).When(x => x.Longitude.HasValue)
                .WithMessage("Longitude must be between -180 and 180");

            RuleFor(x => x.VerificationStatus)
                .Must(s => string.IsNullOrEmpty(s) || s == "Pending" || s == "Verified" || s == "Rejected")
                .WithMessage("Verification status must be Pending, Verified, or Rejected");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.LabId)
                .MustAsync(async (labId, cancellationToken) =>
                {
                    var lab = await _labServices.GetByIDAsync(labId);
                    return lab != null && !lab.IsDeleted;
                })
                .WithMessage("Lab does not exist");
        }
    }
}