using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SmartMedicalGuide.Core.Features.Labs.Commands.Models;
using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Core.Features.Labs.Commands.Validators
{
    public class AddLabValidator : AbstractValidator<AddLabCommand>
    {
        private readonly UserManager<User> _userManager;

        public AddLabValidator(UserManager<User> userManager)
        {
            _userManager = userManager;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(x => x.CenterName)
                .NotEmpty().WithMessage("Center name is required")
                .MaximumLength(200).WithMessage("Center name cannot exceed 200 characters");

            RuleFor(x => x.Location)
                .MaximumLength(500).WithMessage("Location cannot exceed 500 characters");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters");

            RuleFor(x => x.LicenseNumber)
                .MaximumLength(50).WithMessage("License number cannot exceed 50 characters");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("Invalid email format")
                .MaximumLength(256).WithMessage("Email cannot exceed 256 characters");

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90).When(x => x.Latitude.HasValue)
                .WithMessage("Latitude must be between -90 and 90");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).When(x => x.Longitude.HasValue)
                .WithMessage("Longitude must be between -180 and 180");

            RuleFor(x => x.LabImageUrl)
                .MaximumLength(500).When(x => !string.IsNullOrEmpty(x.LabImageUrl))
                .WithMessage("Image URL cannot exceed 500 characters");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Description cannot exceed 2000 characters");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.UserId)
                .MustAsync(async (userId, cancellationToken) =>
                {
                    var user = await _userManager.FindByIdAsync(userId.ToString());
                    return user != null;
                })
                .WithMessage("User does not exist");
        }
    }
}