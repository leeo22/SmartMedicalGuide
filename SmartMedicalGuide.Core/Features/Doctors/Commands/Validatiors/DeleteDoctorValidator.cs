using FluentValidation;
using SmartMedicalGuide.Core.Features.Doctors.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Doctors.Commands.Validators
{
    public class DeleteDoctorValidator : AbstractValidator<DeleteDoctorCommand>
    {
        #region Fields
        private readonly IDoctorServices _doctorServices;
        #endregion

        #region Constructors
        public DeleteDoctorValidator(IDoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
            ApplyValidationRules();
        }
        #endregion

        #region Validation Rules
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("DoctorId must be greater than 0")
                .MustAsync(async (id, cancellationToken) =>
                {
                    var doctor = await _doctorServices.GetByIDAsync(id);
                    return doctor != null;
                })
                .WithMessage("Doctor does not exist");
        }
        #endregion
    }
}