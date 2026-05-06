using FluentValidation;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Validators
{
    public class AddPrescriptionItemValidator : AbstractValidator<AddPrescriptionItemCommand>
    {
        private readonly IPrescriptionServices _prescriptionServices;

        public AddPrescriptionItemValidator(IPrescriptionServices prescriptionServices)
        {
            _prescriptionServices = prescriptionServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.PrescriptionId)
                .GreaterThan(0).WithMessage("PrescriptionId must be greater than 0");

            RuleFor(x => x.MedicineName)
                .NotEmpty().WithMessage("Medicine name is required")
                .MaximumLength(200).WithMessage("Medicine name cannot exceed 200 characters");

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
            RuleFor(x => x.PrescriptionId)
                .MustAsync(async (prescriptionId, cancellationToken) =>
                {
                    var prescription = await _prescriptionServices.GetByIDAsync(prescriptionId);
                    return prescription != null && !prescription.IsDeleted;
                })
                .WithMessage("Prescription does not exist");
        }
    }
}