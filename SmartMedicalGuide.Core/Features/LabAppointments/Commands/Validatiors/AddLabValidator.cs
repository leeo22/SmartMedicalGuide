using FluentValidation;
using SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Commands.Validators
{
    public class AddLabAppointmentValidator : AbstractValidator<AddLabAppointmentCommand>
    {
        private readonly IPatientServices _patientServices;
        private readonly ILabServices _labServices;

        public AddLabAppointmentValidator(IPatientServices patientServices, ILabServices labServices)
        {
            _patientServices = patientServices;
            _labServices = labServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("PatientId must be greater than 0");

            RuleFor(x => x.LabId)
                .GreaterThan(0).WithMessage("LabId must be greater than 0");

            RuleFor(x => x.AppointmentDate)
                .NotNull().WithMessage("Appointment date is required")
                .GreaterThan(DateTime.UtcNow).WithMessage("Appointment date must be in the future");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required")
                .MaximumLength(200).WithMessage("Full name cannot exceed 200 characters");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required")
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0).When(x => x.Price.HasValue)
                .WithMessage("Price must be greater than 0");

            RuleFor(x => x.BookingSource)
                .MaximumLength(50).WithMessage("Booking source cannot exceed 50 characters");
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

            RuleFor(x => x.LabId)
                .MustAsync(async (labId, cancellationToken) =>
                {
                    var lab = await _labServices.GetByIDAsync(labId);
                    return lab != null;
                })
                .WithMessage("Lab does not exist");
        }
    }
}