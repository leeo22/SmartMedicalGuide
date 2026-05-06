using FluentValidation;
using SmartMedicalGuide.Core.Features.Reviews.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Reviews.Commands.Validators
{
    public class AddReviewValidator : AbstractValidator<AddReviewCommand>
    {
        private readonly IPatientServices _patientServices;
        private readonly IDoctorServices _doctorServices;
        private readonly ILabServices _labServices;
        private readonly string[] _validTargetTypes = { "Doctor", "Lab" };

        public AddReviewValidator(IPatientServices patientServices, IDoctorServices doctorServices, ILabServices labServices)
        {
            _patientServices = patientServices;
            _doctorServices = doctorServices;
            _labServices = labServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("PatientId must be greater than 0");

            RuleFor(x => x.TargetType)
                .NotEmpty().WithMessage("TargetType is required")
                .Must(type => _validTargetTypes.Contains(type))
                .WithMessage($"TargetType must be one of: {string.Join(", ", _validTargetTypes)}");

            RuleFor(x => x.TargetId)
                .GreaterThan(0).WithMessage("TargetId must be greater than 0");

            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5");

            RuleFor(x => x.Comment)
                .MaximumLength(2000).WithMessage("Comment cannot exceed 2000 characters");
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

            RuleFor(x => x)
                .MustAsync(async (command, cancellationToken) =>
                {
                    if (command.TargetType == "Doctor")
                    {
                        var doctor = await _doctorServices.GetByIDAsync(command.TargetId);
                        return doctor != null && !doctor.IsDeleted;
                    }
                    //else if (command.TargetType == "Lab")
                    //{
                    //    var lab = await _labServices.(command.TargetId);
                    //    return lab != null && !lab.IsDeleted;
                    //}
                    return false;
                })
                .WithMessage("Target (Doctor/Lab) does not exist");
        }
    }
}