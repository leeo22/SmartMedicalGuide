using FluentValidation;
using SmartMedicalGuide.Core.Features.Authentication.Queries.Models;


namespace SmartMedicalGuide.Core.Features.Authentication.Commands.Validators
{
    public class ConfirmResetPasswordQueryValidator : AbstractValidator<ConfirmResetPasswordQuery>
    {
        #region Fields
        //private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public ConfirmResetPasswordQueryValidator()
        {
            //_localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Code)
                 .NotEmpty().WithMessage("_localizer[SharedResourcesKeys.NotEmpty]")
                 .NotNull().WithMessage("_localizer[SharedResourcesKeys.Required]");
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("_localizer[SharedResourcesKeys.NotEmpty]")
                 .NotNull().WithMessage("_localizer[SharedResourcesKeys.Required]");

        }

        public void ApplyCustomValidationsRules()
        {
        }

        #endregion

    }
}