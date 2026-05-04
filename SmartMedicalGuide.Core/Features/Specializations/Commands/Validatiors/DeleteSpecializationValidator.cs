using FluentValidation;
using SmartMedicalGuide.Core.Features.Specializations.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Specializations.Commands.Validators
{
    public class DeleteSpecializationValidator : AbstractValidator<DeleteSpecializationCommand>
    {
        private readonly ISpecializationServices _specializationServices;

        public DeleteSpecializationValidator(ISpecializationServices specializationServices)
        {
            _specializationServices = specializationServices;
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Invalid specialization ID")
                .MustAsync(async (id, cancellationToken) =>
                {
                    var specialization = await _specializationServices.GetByIDAsync(id);
                    return specialization != null;
                })
                .WithMessage("Specialization not found");
        }
    }
}