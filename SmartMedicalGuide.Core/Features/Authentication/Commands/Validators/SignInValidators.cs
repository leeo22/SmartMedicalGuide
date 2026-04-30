using SmartMedicalGuide.Core.Features.Authentication.Commands.Models;
using FluentValidation;

namespace SmartMedicalGuide.Core.Features.Authentication.Commands.Validators
{
    internal class SignInValidators : AbstractValidator<SignInCommand>
    {
        #region Fields
        #endregion

        #region Constructors
        public SignInValidators()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName")
                .NotNull().WithMessage("UserName");

            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage("Password")
                 .NotNull().WithMessage("Password");


        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }

}
