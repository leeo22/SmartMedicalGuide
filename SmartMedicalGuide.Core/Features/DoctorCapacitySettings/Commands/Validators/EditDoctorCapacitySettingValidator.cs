using FluentValidation;
using SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Commands.Models;

namespace SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Commands.Validators
{
    public class EditDoctorCapacitySettingValidator : AbstractValidator<EditDoctorCapacitySettingCommand>
    {
        public EditDoctorCapacitySettingValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Setting ID must be greater than 0");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0).WithMessage("Doctor ID must be greater than 0");

            RuleFor(x => x.DailyCapacity)
                .GreaterThan(0).WithMessage("Daily capacity must be greater than 0")
                .LessThanOrEqualTo(x => x.MaxLimit).WithMessage("Daily capacity cannot exceed max limit");

            RuleFor(x => x.MaxLimit)
                .GreaterThan(0).WithMessage("Max limit must be greater than 0");

            RuleFor(x => x.WorkDays)
                .IsInEnum().WithMessage("Invalid work days value");

            RuleFor(x => x.BookingType)
                .IsInEnum().WithMessage("Invalid booking type value");

            RuleFor(x => x.ShiftType)
                .IsInEnum().WithMessage("Invalid shift type value");
        }
    }
}