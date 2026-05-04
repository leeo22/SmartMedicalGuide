using FluentValidation;
using SmartMedicalGuide.Core.Features.Specializations.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Specializations.Commands.Validators
{
    public class EditSpecializationValidator : AbstractValidator<EditSpecializationCommand>
    {
        private readonly ISpecializationServices _specializationServices;

        public EditSpecializationValidator(ISpecializationServices specializationServices)
        {
            _specializationServices = specializationServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.SpecializationId)
                .GreaterThan(0).WithMessage("Invalid specialization ID");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("Specialization name cannot be null")
                .NotEmpty().WithMessage("Specialization name is required")
                .MaximumLength(100).WithMessage("Specialization name cannot exceed 100 characters");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (command, name, cancellationToken) =>
                {
                    var existing = await _specializationServices.GetByNameAsync(name);
                    return existing == null || existing.SpecializationId == command.SpecializationId;
                })
                .WithMessage("Another specialization with this name already exists");

            RuleFor(x => x.SpecializationId)
                .MustAsync(async (id, cancellationToken) =>
                {
                    var specialization = await _specializationServices.GetByIDAsync(id);
                    return specialization != null;
                })
                .WithMessage("Specialization not found");
        }
    }
}