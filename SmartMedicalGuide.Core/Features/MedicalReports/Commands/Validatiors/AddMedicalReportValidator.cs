using FluentValidation;
using SmartMedicalGuide.Core.Features.MedicalReports.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Commands.Validators
{
    public class AddMedicalReportValidator : AbstractValidator<AddMedicalReportCommand>
    {
        private readonly IPatientServices _patientServices;
        private readonly IDoctorServices _doctorServices;

        public AddMedicalReportValidator(IPatientServices patientServices, IDoctorServices doctorServices)
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

            RuleFor(x => x.ReportDate)
                .NotNull().WithMessage("Report date is required")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Report date cannot be in the future");

            RuleFor(x => x.ReportType)
                .MaximumLength(100).WithMessage("Report type cannot exceed 100 characters");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Description cannot exceed 2000 characters");
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
                    return doctor != null;
                })
                .WithMessage("Doctor does not exist");
        }
    }
}