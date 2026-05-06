using FluentValidation;
using SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Commands.Validators
{
    public class EditLabAppointmentValidator : AbstractValidator<EditLabAppointmentCommand>
    {
        private readonly ILabAppointmentServices _appointmentServices;

        public EditLabAppointmentValidator(ILabAppointmentServices appointmentServices)
        {
            _appointmentServices = appointmentServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.LabAppointmentId)
                .GreaterThan(0).WithMessage("LabAppointmentId must be greater than 0");

            RuleFor(x => x.AppointmentDate)
                .GreaterThan(DateTime.UtcNow).When(x => x.AppointmentDate.HasValue)
                .WithMessage("Appointment date must be in the future");

            RuleFor(x => x.Price)
                .GreaterThan(0).When(x => x.Price.HasValue)
                .WithMessage("Price must be greater than 0");

            RuleFor(x => x.Status)
                .Must(s => string.IsNullOrEmpty(s) || s == "Pending" || s == "Confirmed" || s == "Completed" || s == "Cancelled")
                .WithMessage("Status must be Pending, Confirmed, Completed, or Cancelled");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.LabAppointmentId)
                .MustAsync(async (appointmentId, cancellationToken) =>
                {
                    var appointment = await _appointmentServices.GetByIDAsync(appointmentId);
                    return appointment != null && !appointment.IsDeleted;
                })
                .WithMessage("Appointment does not exist");
        }
    }
}