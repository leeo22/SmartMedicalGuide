using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SmartMedicalGuide.Core.Features.Doctors.Commands.Models;
using SmartMedicalGuide.Data.Entities.Identity;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Doctors.Commands.Validators
{
    public class AddDoctorValidator : AbstractValidator<AddDoctorCommand>
    {
        private readonly UserManager<User> _userManager;
        private readonly ISpecializationServices _specializationServices;

        public AddDoctorValidator(UserManager<User> userManager, ISpecializationServices specializationServices)
        {
            _userManager = userManager;
            _specializationServices = specializationServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(x => x.ConsultationPrice)
                .GreaterThan(0).WithMessage("Consultation price must be greater than 0")
                .When(x => x.ConsultationPrice.HasValue);

            RuleFor(x => x.LicenseNumber)
                .MaximumLength(50).WithMessage("License number cannot exceed 50 characters");

            RuleFor(x => x.Bio)
                .MaximumLength(1000).WithMessage("Bio cannot exceed 1000 characters");

            RuleFor(x => x.YearsOfExperience)
                .GreaterThanOrEqualTo(0).WithMessage("Years of experience must be greater than or equal to 0")
                .LessThanOrEqualTo(60).WithMessage("Years of experience cannot exceed 60")
                .When(x => x.YearsOfExperience.HasValue);

            RuleFor(x => x.Gender)
                .Must(g => string.IsNullOrEmpty(g) || g == "Male" || g == "Female")
                .WithMessage("Gender must be Male or Female");
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

            RuleFor(x => x.SpecializationId)
                .MustAsync(async (specId, cancellationToken) =>
                {
                    if (!specId.HasValue) return true;
                    var specialization = await _specializationServices.GetByIDAsync(specId.Value);
                    return specialization != null;
                })
                .WithMessage("Specialization does not exist");
        }
    }
}