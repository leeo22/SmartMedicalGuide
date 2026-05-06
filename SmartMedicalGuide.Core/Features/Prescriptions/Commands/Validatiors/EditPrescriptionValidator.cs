using FluentValidation;
using SmartMedicalGuide.Core.Features.Prescriptions.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Commands.Validators
{
    public class EditPrescriptionValidator : AbstractValidator<EditPrescriptionCommand>
    {
        private readonly IPrescriptionServices _prescriptionServices;

        public EditPrescriptionValidator(IPrescriptionServices prescriptionServices)
        {
            _prescriptionServices = prescriptionServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.PrescriptionId)
                .GreaterThan(0).WithMessage("PrescriptionId must be greater than 0");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Description cannot exceed 2000 characters");

            RuleFor(x => x.Notes)
                .MaximumLength(1000).WithMessage("Notes cannot exceed 1000 characters");

            RuleFor(x => x.FollowUpDate)
                .GreaterThan(DateTime.UtcNow).When(x => x.FollowUpDate.HasValue)
                .WithMessage("Follow-up date must be in the future");

            RuleFor(x => x.Status)
                .Must(s => string.IsNullOrEmpty(s) || s == "Active" || s == "Completed" || s == "Expired")
                .WithMessage("Status must be Active, Completed, or Expired");
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