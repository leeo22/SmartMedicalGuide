using FluentValidation;
using SmartMedicalGuide.Core.Features.Payments.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Payments.Commands.Validators
{
    public class EditPaymentValidator : AbstractValidator<EditPaymentCommand>
    {
        private readonly IPaymentServices _paymentServices;

        public EditPaymentValidator(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.PaymentId)
                .GreaterThan(0).WithMessage("PaymentId must be greater than 0");

            RuleFor(x => x.PaymentStatus)
                .Must(s => string.IsNullOrEmpty(s) || s == "Pending" || s == "Completed" || s == "Failed")
                .WithMessage("Payment status must be Pending, Completed, or Failed");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.PaymentId)
                .MustAsync(async (paymentId, cancellationToken) =>
                {
                    var payment = await _paymentServices.GetByIDAsync(paymentId);
                    return payment != null && !payment.IsDeleted;
                })
                .WithMessage("Payment does not exist");
        }
    }
}