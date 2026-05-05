using FluentValidation;
using SmartMedicalGuide.Core.Features.Authentication.Commands.Models;

namespace SmartMedicalGuide.Core.Features.Authentication.Commands.Validators
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
    {
        #region Fields
        //private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public ResetPasswordValidator()
        {
            //_localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("")
                 .NotNull().WithMessage("");
            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage("")
                 .NotNull().WithMessage("");
            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.Password).WithMessage("");

        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
