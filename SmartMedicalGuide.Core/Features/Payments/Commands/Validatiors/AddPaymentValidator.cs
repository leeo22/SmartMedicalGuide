using FluentValidation;
using SmartMedicalGuide.Core.Features.Payments.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Payments.Commands.Validators
{
    public class AddPaymentValidator : AbstractValidator<AddPaymentCommand>
    {
        private readonly IDoctorAppointmentServices _doctorAppointmentServices;
        private readonly ILabAppointmentServices _labAppointmentServices;

        public AddPaymentValidator(IDoctorAppointmentServices doctorAppointmentServices, ILabAppointmentServices labAppointmentServices)
        {
            _doctorAppointmentServices = doctorAppointmentServices;
            _labAppointmentServices = labAppointmentServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0");

            RuleFor(x => x.PlatformFee)
                .GreaterThanOrEqualTo(0).WithMessage("Platform fee cannot be negative");

            RuleFor(x => x.DoctorShare)
                .GreaterThanOrEqualTo(0).WithMessage("Doctor share cannot be negative");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Payment method is required");

            RuleFor(x => x.ReceiverName)
                .NotEmpty().When(x => x.PaymentMethod == "BankTransfer")
                .WithMessage("Receiver name is required for bank transfer");

            RuleFor(x => x.ReceiverNumber)
                .NotEmpty().When(x => x.PaymentMethod == "BankTransfer")
                .WithMessage("Receiver number is required for bank transfer");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.DoctorAppointmentId)
                .Must((command, doctorAppointmentId) => doctorAppointmentId.HasValue || command.LabAppointmentId.HasValue)
                .WithMessage("Either DoctorAppointmentId or LabAppointmentId must be provided");

            RuleFor(x => x.DoctorAppointmentId)
                .MustAsync(async (appointmentId, cancellationToken) =>
                {
                    if (!appointmentId.HasValue) return true;
                    var appointment = await _doctorAppointmentServices.GetByIDAsync(appointmentId.Value);
                    return appointment != null;
                })
                .WithMessage("Doctor appointment does not exist");

            //RuleFor(x => x.LabAppointmentId)
            //    .MustAsync(async (appointmentId, cancellationToken) =>
            //    {
            //        if (!appointmentId.HasValue) return true;
            //        var appointment = await _labAppointmentServices.GetByIDAsync(appointmentId.Value);
            //        return appointment != null;
            //    })
            //    .WithMessage("Lab appointment does not exist");
        }
    }
}