using FluentValidation;
using SmartMedicalGuide.Core.Features.Notifications.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Notifications.Commands.Validators
{
    public class EditNotificationValidator : AbstractValidator<EditNotificationCommand>
    {
        private readonly INotificationServices _notificationServices;
        private readonly string[] _validTypes = { "Appointment", "Payment", "Report", "System", "Message" };

        public EditNotificationValidator(INotificationServices notificationServices)
        {
            _notificationServices = notificationServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.NotificationId)
                .GreaterThan(0).WithMessage("NotificationId must be greater than 0");

            RuleFor(x => x.Title)
                .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.Title))
                .WithMessage("Title cannot exceed 200 characters");

            RuleFor(x => x.Message)
                .MaximumLength(2000).When(x => !string.IsNullOrEmpty(x.Message))
                .WithMessage("Message cannot exceed 2000 characters");

            RuleFor(x => x.NotificationType)
                .Must(type => string.IsNullOrEmpty(type) || _validTypes.Contains(type))
                .WithMessage($"NotificationType must be one of: {string.Join(", ", _validTypes)}");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.NotificationId)
                .MustAsync(async (notificationId, cancellationToken) =>
                {
                    var notification = await _notificationServices.GetByIDAsync(notificationId);
                    return notification != null && !notification.IsDeleted;
                })
                .WithMessage("Notification does not exist");
        }
    }
}