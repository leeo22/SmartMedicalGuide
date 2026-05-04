using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SmartMedicalGuide.Core.Features.Patients.Commands.Models;
using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Core.Features.Patients.Commands.Validators
{
    public class AddPatientValidator : AbstractValidator<AddPatientCommand>
    {
        private readonly UserManager<User> _userManager;

        public AddPatientValidator(UserManager<User> userManager)
        {
            _userManager = userManager;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is required")
                .Must(g => g == "Male" || g == "Female")
                .WithMessage("Gender must be Male or Female");

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past");

            RuleFor(x => x.Address)
                .MaximumLength(250).WithMessage("Address cannot exceed 250 characters");
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