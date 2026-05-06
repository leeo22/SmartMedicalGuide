using FluentValidation;
using SmartMedicalGuide.Core.Features.Wallets.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Wallets.Commands.Validators
{
    public class EditWalletValidator : AbstractValidator<EditWalletCommand>
    {
        private readonly IWalletServices _walletServices;

        public EditWalletValidator(IWalletServices walletServices)
        {
            _walletServices = walletServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.WalletId)
                .GreaterThan(0).WithMessage("WalletId must be greater than 0");

            RuleFor(x => x.Currency)
                .MaximumLength(3).WithMessage("Currency must be 3 characters (e.g., SAR, USD)")
                .Must(c => string.IsNullOrEmpty(c) || c == "SAR" || c == "USD" || c == "YER")
                .WithMessage("Currency must be SAR, USD, or YER");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.WalletId)
                .MustAsync(async (walletId, cancellationToken) =>
                {
                    var wallet = await _walletServices.GetByIDAsync(walletId);
                    return wallet != null && !wallet.IsDeleted;
                })
                .WithMessage("Wallet does not exist");
        }
    }
}