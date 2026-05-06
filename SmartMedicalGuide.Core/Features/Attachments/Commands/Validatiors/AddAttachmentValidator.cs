using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SmartMedicalGuide.Core.Features.Attachments.Commands.Models;
using SmartMedicalGuide.Data.Entities.Identity;

namespace SmartMedicalGuide.Core.Features.Attachments.Commands.Validators
{
    public class AddAttachmentValidator : AbstractValidator<AddAttachmentCommand>
    {
        private readonly UserManager<User> _userManager;
        private readonly string[] _validEntityTypes = { "MedicalReport", "Prescription", "Profile", "Message" };

        public AddAttachmentValidator(UserManager<User> userManager)
        {
            _userManager = userManager;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(x => x.File)
                .NotNull().WithMessage("File is required")
                .Must(file => file != null && file.Length > 0).WithMessage("File cannot be empty");

            RuleFor(x => x.RelatedEntityType)
                .Must(type => string.IsNullOrEmpty(type) || _validEntityTypes.Contains(type))
                .WithMessage($"RelatedEntityType must be one of: {string.Join(", ", _validEntityTypes)}");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
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