using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SmartMedicalGuide.Core.Features.Notifications.Commands.Models;
using SmartMedicalGuide.Data.Entities.Identity;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Notifications.Commands.Validators
{
    public class AddNotificationValidator : AbstractValidator<AddNotificationCommand>
    {
        private readonly UserManager<User> _userManager;
        private readonly string[] _validTypes = { "Appointment", "Payment", "Report", "System", "Message" };

        public AddNotificationValidator(UserManager<User> userManager)
        {
            _userManager = userManager;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200).WithMessage("Title cannot exceed 200 characters");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message is required")
                .MaximumLength(2000).WithMessage("Message cannot exceed 2000 characters");

            RuleFor(x => x.NotificationType)
                .Must(type => string.IsNullOrEmpty(type) || _validTypes.Contains(type))
                .WithMessage($"NotificationType must be one of: {string.Join(", ", _validTypes)}");

            RuleFor(x => x.RelatedEntityType)
                .MaximumLength(100).WithMessage("RelatedEntityType cannot exceed 100 characters");

            RuleFor(x => x.ActionUrl)
                .MaximumLength(500).WithMessage("ActionUrl cannot exceed 500 characters");

            RuleFor(x => x.ImageUrl)
                .MaximumLength(500).WithMessage("ImageUrl cannot exceed 500 characters");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.UserId)
                .MustAsync(async (userId, cancellationToken) =>
                {
                    var user = await _userManager.FindByIdAsync(userId.ToString());
                    return user != null;
                })
                .WithMessage("User does not exist");
        }
    }
}