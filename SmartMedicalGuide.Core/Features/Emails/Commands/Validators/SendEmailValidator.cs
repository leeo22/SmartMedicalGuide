using FluentValidation;
using SmartMedicalGuide.Core.Features.Emails.Commands.Models;

namespace SmartMedicalGuide.Core.Features.Emails.Commands.Validators
{
    public class SendEmailValidator : AbstractValidator<SendEmailCommand>
    {
        #region Fields
        //private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region Constructors
        public SendEmailValidator()
        {
            //_localizer = localizer;
            ApplyValidationsRules();
        }
        #endregion
        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("")
                 .NotNull().WithMessage("");

            RuleFor(x => x.Message)
                 .NotEmpty().WithMessage("")
                 .NotNull().WithMessage("");
        }
        #endregion
    }
}
