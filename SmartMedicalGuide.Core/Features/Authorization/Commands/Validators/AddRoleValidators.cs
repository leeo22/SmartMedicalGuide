using FluentValidation;
using SmartMedicalGuide.Core.Features.Authorization.Commands.Models;
using SmartMedicalGuide.Service.Abstracts;

namespace SmartMedicalGuide.Core.Features.Authorization.Commands.Validators
{
    public class AddRoleValidators : AbstractValidator<AddRoleCommand>
    {
        #region Fields
        private readonly IAuthorizationService _authorizationService;
        #endregion
        #region Constructors

        #endregion
        public AddRoleValidators(
                                 IAuthorizationService authorizationService)
        {

            _authorizationService = authorizationService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.RoleName)
                 .NotEmpty().WithMessage("Role Most not empty")
                 .NotNull().WithMessage("Role Most not");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.RoleName)
                .MustAsync(async (Key, CancellationToken) => !await _authorizationService.IsRoleExistByName(Key))
                .WithMessage("RoleExist");
        }

        #endregion
    }
}
