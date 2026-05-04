using FluentValidation;
using SmartMedicalGuide.Core.Features.DoctorSchedules.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.DoctorSchedules.Commands.Validators
{
    public class EditDoctorScheduleValidator : AbstractValidator<EditDoctorScheduleCommand>
    {
        private readonly IDoctorScheduleServices _scheduleServices;

        public EditDoctorScheduleValidator(IDoctorScheduleServices scheduleServices)
        {
            _scheduleServices = scheduleServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.ScheduleId)
                .GreaterThan(0).WithMessage("ScheduleId must be greater than 0");

            RuleFor(x => x)
                .Must(x => x.StartTime < x.EndTime)
                .When(x => x.StartTime.HasValue && x.EndTime.HasValue)
                .WithMessage("Start time must be before end time");

            RuleFor(x => x.MaxAppointmentsPerSlot)
                .GreaterThan(0).When(x => x.MaxAppointmentsPerSlot > 0)
                .WithMessage("Max appointments per slot must be greater than 0");

            RuleFor(x => x.SlotDuration)
                .GreaterThan(0).When(x => x.SlotDuration > 0)
                .WithMessage("Slot duration must be greater than 0");

            RuleFor(x => x)
                .Must(x => !x.BreakStartTime.HasValue || !x.BreakEndTime.HasValue || x.BreakStartTime < x.BreakEndTime)
                .WithMessage("Break start time must be before break end time");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.ScheduleId)
                .MustAsync(async (scheduleId, cancellationToken) =>
                {
                    var schedule = await _scheduleServices.GetByIDAsync(scheduleId);
                    return schedule != null && !schedule.IsDeleted;
                })
                .WithMessage("Schedule does not exist");
        }
    }
}