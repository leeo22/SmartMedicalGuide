using FluentValidation;
using SmartMedicalGuide.Core.Features.Specializations.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Specializations.Commands.Validators
{
    public class AddSpecializationValidator : AbstractValidator<AddSpecializationCommand>
    {
        private readonly ISpecializationServices _specializationServices;

        public AddSpecializationValidator(ISpecializationServices specializationServices)
        {
            _specializationServices = specializationServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
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
                .MustAsync(async (name, cancellationToken) =>
                {
                    var existing = await _specializationServices.GetByNameAsync(name);
                    return existing == null;
                })
                .WithMessage("Specialization with this name already exists");
        }
    }
}