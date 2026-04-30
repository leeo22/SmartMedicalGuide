using FluentValidation;
using SmartMedicalGuide.Core.Features.Users.Commands.Models;

namespace SmartMedicalGuide.Core.Features.Users.Commands.Validatiors
{
    public class ChangeUserPasswordValidatior : AbstractValidator<ChangeUserPasswordCommand>
    {
        #region Fields
        #endregion

        #region Constructors
        public ChangeUserPasswordValidatior()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("not empty")
                .NotNull().WithMessage("not empty");

            RuleFor(x => x.CurrentPassword)
                 .NotEmpty().WithMessage("not empty")
                 .NotNull().WithMessage("not empty");
            RuleFor(x => x.NewPassword)
                 .NotEmpty().WithMessage("not empty")
                 .NotNull().WithMessage("not empty");
            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.NewPassword).WithMessage("not empty");

        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
