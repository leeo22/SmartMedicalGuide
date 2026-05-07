using FluentValidation;
using SmartMedicalGuide.Core.Features.Transactions.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Transactions.Commands.Validators
{
    public class AddTransactionValidator : AbstractValidator<AddTransactionCommand>
    {
        private readonly IWalletServices _walletServices;
        private readonly string[] _validTypes = { "Credit", "Debit" };
        private readonly string[] _validReferenceTypes = { "DoctorAppointment", "LabAppointment", "Withdrawal", "Deposit" };

        public AddTransactionValidator(IWalletServices walletServices)
        {
            _walletServices = walletServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.WalletId)
                .GreaterThan(0).WithMessage("WalletId must be greater than 0");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Transaction type is required")
                .Must(t => _validTypes.Contains(t))
                .WithMessage($"Transaction type must be one of: {string.Join(", ", _validTypes)}");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.ReferenceType)
                .Must(rt => string.IsNullOrEmpty(rt) || _validReferenceTypes.Contains(rt))
                .WithMessage($"Reference type must be one of: {string.Join(", ", _validReferenceTypes)}");

            RuleFor(x => x.TransactionReference)
                .MaximumLength(100).WithMessage("Transaction reference cannot exceed 100 characters");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.WalletId)
                .MustAsync(async (walletId, cancellationToken) =>
                {
                    var wallet = await _walletServices.GetByIDAsync(walletId);
                    return wallet != null;
                })
                .WithMessage("Wallet does not exist");
        }
    }
}