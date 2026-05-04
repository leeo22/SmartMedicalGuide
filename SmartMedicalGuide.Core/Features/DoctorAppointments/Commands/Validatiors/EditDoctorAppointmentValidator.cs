using FluentValidation;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Validators
{
    public class EditDoctorAppointmentValidator : AbstractValidator<EditDoctorAppointmentCommand>
    {
        private readonly IDoctorAppointmentServices _appointmentServices;

        public EditDoctorAppointmentValidator(IDoctorAppointmentServices appointmentServices)
        {
            _appointmentServices = appointmentServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.AppointmentId)
                .GreaterThan(0).WithMessage("AppointmentId must be greater than 0");

            RuleFor(x => x.AppointmentDate)
                .GreaterThan(DateTime.UtcNow).When(x => x.AppointmentDate.HasValue)
                .WithMessage("Appointment date must be in the future");

            RuleFor(x => x.Status)
                .Must(s => string.IsNullOrEmpty(s) ||
                    s == "Pending" || s == "Confirmed" || s == "Completed" || s == "Cancelled")
                .WithMessage("Status must be Pending, Confirmed, Completed, or Cancelled");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.AppointmentId)
                .MustAsync(async (id, cancellationToken) =>
                {
                    var appointment = await _appointmentServices.GetByIDAsync(id);
                    return appointment != null;
                })
                .WithMessage("Appointment does not exist");
        }
    }
}