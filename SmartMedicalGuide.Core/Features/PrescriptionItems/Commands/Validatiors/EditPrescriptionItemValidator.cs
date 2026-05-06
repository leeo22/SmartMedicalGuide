using FluentValidation;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Validators
{
    public class EditPrescriptionItemValidator : AbstractValidator<EditPrescriptionItemCommand>
    {
        private readonly IPrescriptionItemServices _itemServices;

        public EditPrescriptionItemValidator(IPrescriptionItemServices itemServices)
        {
            _itemServices = itemServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.ItemId)
                .GreaterThan(0).WithMessage("ItemId must be greater than 0");

            RuleFor(x => x.MedicineName)
                .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.MedicineName))
                .WithMessage("Medicine name cannot exceed 200 characters");

            RuleFor(x => x.Dosage)
                .MaximumLength(100).WithMessage("Dosage cannot exceed 100 characters");

            RuleFor(x => x.Duration)
                .MaximumLength(100).WithMessage("Duration cannot exceed 100 characters");

            RuleFor(x => x.Frequency)
                .MaximumLength(100).WithMessage("Frequency cannot exceed 100 characters");

            RuleFor(x => x.Instructions)
                .MaximumLength(500).WithMessage("Instructions cannot exceed 500 characters");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).When(x => x.Quantity.HasValue)
                .WithMessage("Quantity must be greater than 0");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.ItemId)
                .MustAsync(async (itemId, cancellationToken) =>
                {
                    var item = await _itemServices.GetByIDAsync(itemId);
                    return item != null && !item.IsDeleted;
                })
                .WithMessage("Prescription item does not exist");
        }
    }
}