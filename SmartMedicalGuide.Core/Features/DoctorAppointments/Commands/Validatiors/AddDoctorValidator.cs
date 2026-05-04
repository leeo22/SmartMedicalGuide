using FluentValidation;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Validators
{
    public class AddDoctorAppointmentValidator : AbstractValidator<AddDoctorAppointmentCommand>
    {
        private readonly IDoctorServices _doctorServices;
        private readonly IPatientServices _patientServices;

        public AddDoctorAppointmentValidator(IDoctorServices doctorServices, IPatientServices patientServices)
        {
            _doctorServices = doctorServices;
            _patientServices = patientServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0).When(x => x.PatientId.HasValue).WithMessage("PatientId must be greater than 0");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0).When(x => x.DoctorId.HasValue).WithMessage("DoctorId must be greater than 0");

            RuleFor(x => x.AppointmentDate)
                .NotNull().WithMessage("Appointment date is required")
                .GreaterThan(DateTime.UtcNow).WithMessage("Appointment date must be in the future");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required when PatientId is not provided")
                .When(x => !x.PatientId.HasValue);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required when PatientId is not provided")
                .When(x => !x.PatientId.HasValue);
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.DoctorId)
                .MustAsync(async (doctorId, cancellationToken) =>
                {
                    if (!doctorId.HasValue) return true;
                    var doctor = await _doctorServices.GetByIDAsync(doctorId.Value);
                    return doctor != null;
                })
                .WithMessage("Doctor does not exist");

            RuleFor(x => x.PatientId)
                .MustAsync(async (patientId, cancellationToken) =>
                {
                    if (!patientId.HasValue) return true;
                    var patient = await _patientServices.GetByIDAsync(patientId.Value);
                    return patient != null;
                })
                .WithMessage("Patient does not exist");
        }
    }
}