using FluentValidation;
using SmartMedicalGuide.Core.Features.Transactions.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Transactions.Commands.Validators
{
    public class EditTransactionValidator : AbstractValidator<EditTransactionCommand>
    {
        private readonly ITransactionServices _transactionServices;
        private readonly string[] _validTypes = { "Credit", "Debit" };
        private readonly string[] _validStatuses = { "Pending", "Completed", "Failed" };

        public EditTransactionValidator(ITransactionServices transactionServices)
        {
            _transactionServices = transactionServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.TransactionId)
                .GreaterThan(0).WithMessage("TransactionId must be greater than 0");

            RuleFor(x => x.Amount)
                .GreaterThan(0).When(x => x.Amount.HasValue)
                .WithMessage("Amount must be greater than 0");

            RuleFor(x => x.Type)
                .Must(t => string.IsNullOrEmpty(t) || _validTypes.Contains(t))
                .WithMessage($"Transaction type must be one of: {string.Join(", ", _validTypes)}");

            RuleFor(x => x.Status)
                .Must(s => string.IsNullOrEmpty(s) || _validStatuses.Contains(s))
                .WithMessage($"Status must be one of: {string.Join(", ", _validStatuses)}");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.TransactionId)
                .MustAsync(async (transactionId, cancellationToken) =>
                {
                    var transaction = await _transactionServices.GetByIDAsync(transactionId);
                    return transaction != null && !transaction.IsDeleted;
                })
                .WithMessage("Transaction does not exist");
        }
    }
}