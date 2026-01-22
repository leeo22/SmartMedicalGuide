using FluentValidation;
using SmartMedicalGuide.Core.Features.Patients.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Patients.Commands.Validatiors
{
    public class AddPatientValidator : AbstractValidator<AddPatientCommand>
    {
        #region Fields
        private readonly IPatientServices _patientServices;
        #endregion

        #region Constructors
        public AddPatientValidator(IPatientServices patientServices)
        {
            _patientServices = patientServices;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();


        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Name Must Not Be Empty")
                .NotNull().WithMessage("Name Must Not Be Null")
                .MinimumLength(10).WithMessage("MinimumLength is 10");


            RuleFor(x => x.Age)
                .NotEmpty().WithMessage("{PropertyName}Age Must Not Be Empty")
                .NotNull().WithMessage("{PropertyName}Age Must Not Be Null");
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.Phone)
                .MustAsync(async (Key, CancellationToken) => !await _patientServices.IsPhoneExist(Key))
                .WithMessage("Phon is Exist");

        }
        #endregion


    }
}
