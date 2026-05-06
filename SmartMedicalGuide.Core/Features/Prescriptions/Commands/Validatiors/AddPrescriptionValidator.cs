using FluentValidation;
using SmartMedicalGuide.Core.Features.Prescriptions.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Commands.Validators
{
    public class AddPrescriptionValidator : AbstractValidator<AddPrescriptionCommand>
    {
        private readonly IDoctorAppointmentServices _appointmentServices;
        private readonly IDoctorServices _doctorServices;
        private readonly IPatientServices _patientServices;

        public AddPrescriptionValidator(
            IDoctorAppointmentServices appointmentServices,
            IDoctorServices doctorServices,
            IPatientServices patientServices)
        {
            _appointmentServices = appointmentServices;
            _doctorServices = doctorServices;
            _patientServices = patientServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.DoctorAppointmentId)
                .GreaterThan(0).WithMessage("DoctorAppointmentId must be greater than 0");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0).WithMessage("DoctorId must be greater than 0");

            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("PatientId must be greater than 0");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Description cannot exceed 2000 characters");

            RuleFor(x => x.Notes)
                .MaximumLength(1000).WithMessage("Notes cannot exceed 1000 characters");

            RuleFor(x => x.FollowUpDate)
                .GreaterThan(DateTime.UtcNow).When(x => x.FollowUpDate.HasValue)
                .WithMessage("Follow-up date must be in the future");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.DoctorAppointmentId)
                .MustAsync(async (appointmentId, cancellationToken) =>
                {
                    var appointment = await _appointmentServices.GetByIDAsync(appointmentId);
                    return appointment != null;
                })
                .WithMessage("Doctor appointment does not exist");

            RuleFor(x => x.DoctorId)
                .MustAsync(async (doctorId, cancellationToken) =>
                {
                    var doctor = await _doctorServices.GetByIDAsync(doctorId);
                    return doctor != null;
                })
                .WithMessage("Doctor does not exist");

            RuleFor(x => x.PatientId)
                .MustAsync(async (patientId, cancellationToken) =>
                {
                    var patient = await _patientServices.GetByIDAsync(patientId);
                    return patient != null;
                })
                .WithMessage("Patient does not exist");
        }
    }
}