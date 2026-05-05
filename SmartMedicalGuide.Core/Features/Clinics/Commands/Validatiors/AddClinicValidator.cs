using FluentValidation;
using SmartMedicalGuide.Core.Features.Clinics.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Clinics.Commands.Validators
{
    public class AddClinicValidator : AbstractValidator<AddClinicCommand>
    {
        private readonly IDoctorServices _doctorServices;

        public AddClinicValidator(IDoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.DoctorId)
                .GreaterThan(0).WithMessage("DoctorId must be greater than 0");

            RuleFor(x => x.ClinicName)
                .NotEmpty().WithMessage("Clinic name is required")
                .MaximumLength(200).WithMessage("Clinic name cannot exceed 200 characters");

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

            RuleFor(x => x.ClinicImageUrl)
                .MaximumLength(500).WithMessage("Image URL cannot exceed 500 characters");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Description cannot exceed 2000 characters");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.DoctorId)
                .MustAsync(async (doctorId, cancellationToken) =>
                {
                    var doctor = await _doctorServices.GetByIDAsync(doctorId);
                    return doctor != null;
                })
                .WithMessage("Doctor does not exist");
        }
    }
}