using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SmartMedicalGuide.Core.Features.Wallets.Commands.Models;
using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Core.Features.Wallets.Commands.Validators
{
    public class AddWalletValidator : AbstractValidator<AddWalletCommand>
    {
        private readonly UserManager<User> _userManager;

        public AddWalletValidator(UserManager<User> userManager)
        {
            _userManager = userManager;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(x => x.Currency)
                .MaximumLength(3).WithMessage("Currency must be 3 characters (e.g., SAR, USD)")
                .Must(c => string.IsNullOrEmpty(c) || c == "YER" || c == "SAR" || c == "USD")
                .WithMessage("Currency must be SAR, USD, or YER");

            RuleFor(x => x.DoctorAccountNumber)
                .MaximumLength(100).WithMessage("Account number cannot exceed 100 characters");

            RuleFor(x => x.AccountHolderName)
                .MaximumLength(200).WithMessage("Account holder name cannot exceed 200 characters");

            RuleFor(x => x.BankName)
                .MaximumLength(100).WithMessage("Bank name cannot exceed 100 characters");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.UserId)
                .MustAsync(async (userId, cancellationToken) =>
                {
                    var user = await _userManager.FindByIdAsync(userId.ToString());
                    return user != null;
                })
                .WithMessage("User does not exist");
        }
    }
}