using FluentValidation;
using SmartMedicalGuide.Core.Features.Wallets.Commands.Models;

namespace SmartMedicalGuide.Core.Features.Wallets.Commands.Validators
{
    public class TransferBetweenWalletsValidator : AbstractValidator<TransferBetweenWalletsCommand>
    {
        public TransferBetweenWalletsValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.FromWalletId)
                .GreaterThan(0).WithMessage("FromWalletId must be greater than 0");

            RuleFor(x => x.ToWalletId)
                .GreaterThan(0).WithMessage("ToWalletId must be greater than 0");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0");

            RuleFor(x => x)
                .Must(x => x.FromWalletId != x.ToWalletId)
                .WithMessage("Cannot transfer to the same wallet");
        }
    }
}