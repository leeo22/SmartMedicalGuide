using FluentValidation;
using SmartMedicalGuide.Core.Features.Wallets.Commands.Models;

namespace SmartMedicalGuide.Core.Features.Wallets.Commands.Validators
{
    public class UpdateBalanceValidator : AbstractValidator<UpdateBalanceCommand>
    {
        public UpdateBalanceValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.WalletId)
                .GreaterThan(0).WithMessage("WalletId must be greater than 0");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0");
        }
    }
}