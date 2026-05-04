using FluentValidation;
using SmartMedicalGuide.Core.Features.DoctorSchedules.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.DoctorSchedules.Commands.Validators
{
    public class AddDoctorScheduleValidator : AbstractValidator<AddDoctorScheduleCommand>
    {
        private readonly IDoctorServices _doctorServices;
        private readonly string[] _validDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        public AddDoctorScheduleValidator(IDoctorServices doctorServices)
        {
            _doctorServices = doctorServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.DoctorId)
                .GreaterThan(0).WithMessage("DoctorId must be greater than 0");

            RuleFor(x => x.DayOfWeek)
                .NotEmpty().WithMessage("Day of week is required")
                .Must(day => _validDays.Contains(day)).WithMessage("Invalid day of week");

            RuleFor(x => x.StartTime)
                .NotNull().WithMessage("Start time is required");

            RuleFor(x => x.EndTime)
                .NotNull().WithMessage("End time is required");

            RuleFor(x => x)
                .Must(x => x.StartTime < x.EndTime)
                .WithMessage("Start time must be before end time");

            RuleFor(x => x.MaxAppointmentsPerSlot)
                .GreaterThan(0).WithMessage("Max appointments per slot must be greater than 0")
                .LessThanOrEqualTo(10).WithMessage("Max appointments per slot cannot exceed 10");

            RuleFor(x => x.SlotDuration)
                .GreaterThan(0).WithMessage("Slot duration must be greater than 0")
                .LessThanOrEqualTo(120).WithMessage("Slot duration cannot exceed 120 minutes");

            RuleFor(x => x)
                .Must(x => !x.BreakStartTime.HasValue || !x.BreakEndTime.HasValue || x.BreakStartTime < x.BreakEndTime)
                .WithMessage("Break start time must be before break end time");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.DoctorId)
                .MustAsync(async (doctorId, cancellationToken) =>
                {
                    var doctor = await _doctorServices.GetByIDAsync(doctorId);
                    return doctor != null;
                })
                .WithMessage("Doctor does not exist");
        }
    }
}