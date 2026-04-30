using FluentValidation;
using SmartMedicalGuide.Core.Features.Authorization.Commands.Models;

namespace SmartMedicalGuide.Core.Features.Authorization.Commands.Validators
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        #region Fields
        #endregion
        #region Constructors

        #endregion
        public EditRoleValidator()
        {

            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage("An Error")
                 .NotNull().WithMessage("An Error");

            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("An Error")
                 .NotNull().WithMessage("An Error");
        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
