using FluentValidation;
using SmartMedicalGuide.Core.Features.Favorites.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Favorites.Commands.Validators
{
    public class AddFavoriteValidator : AbstractValidator<AddFavoriteCommand>
    {
        private readonly IPatientServices _patientServices;
        private readonly IDoctorServices _doctorServices;

        public AddFavoriteValidator(IPatientServices patientServices, IDoctorServices doctorServices)
        {
            _patientServices = patientServices;
            _doctorServices = doctorServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("PatientId must be greater than 0");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0).WithMessage("DoctorId must be greater than 0");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.PatientId)
                .MustAsync(async (patientId, cancellationToken) =>
                {
                    var patient = await _patientServices.GetByIDAsync(patientId);
                    return patient != null;
                })
                .WithMessage("Patient does not exist");

            RuleFor(x => x.DoctorId)
                .MustAsync(async (doctorId, cancellationToken) =>
                {
                    var doctor = await _doctorServices.GetByIDAsync(doctorId);
                    return doctor != null && !doctor.IsDeleted;
                })
                .WithMessage("Doctor does not exist");
        }
    }
}