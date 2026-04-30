using FluentValidation;
using SmartMedicalGuide.Core.Features.Users.Commands.Models;

namespace SmartMedicalGuide.Core.Features.Users.Commands.Validatiors
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        #region Fields
        #endregion
        #region Constructors
        public AddUserValidator()
        {
            ApplyValdetionsRules();


        }
        #endregion
        #region Handle Function
        public void ApplyValdetionsRules()
        {
            RuleFor(x => x.FullName)
                .NotNull().WithMessage("Full Name cannot be null.")
                .NotEmpty().WithMessage("Full Name is required.")
                .MaximumLength(100).WithMessage("Full Name is less than 100 char");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name is required.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone Number is required.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
            RuleFor(x => x.ConfirmPassword)
                .Matches(x => x.Password).WithMessage("Confirm Password must match Password.");


        }
        #endregion
    }
}
