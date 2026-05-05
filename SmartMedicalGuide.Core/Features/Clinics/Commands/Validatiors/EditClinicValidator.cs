using FluentValidation;
using SmartMedicalGuide.Core.Features.Clinics.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Clinics.Commands.Validators
{
    public class EditClinicValidator : AbstractValidator<EditClinicCommand>
    {
        private readonly IClinicServices _clinicServices;

        public EditClinicValidator(IClinicServices clinicServices)
        {
            _clinicServices = clinicServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.ClinicId)
                .GreaterThan(0).WithMessage("ClinicId must be greater than 0");

            RuleFor(x => x.ClinicName)
                .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.ClinicName))
                .WithMessage("Clinic name cannot exceed 200 characters");

            RuleFor(x => x.Location)
                .MaximumLength(500).WithMessage("Location cannot exceed 500 characters");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters");

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
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.ClinicId)
                .MustAsync(async (clinicId, cancellationToken) =>
                {
                    var clinic = await _clinicServices.GetByIDAsync(clinicId);
                    return clinic != null && !clinic.IsDeleted;
                })
                .WithMessage("Clinic does not exist");
        }
    }
}