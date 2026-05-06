using FluentValidation;
using SmartMedicalGuide.Core.Features.Attachments.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Attachments.Commands.Validators
{
    public class EditAttachmentValidator : AbstractValidator<EditAttachmentCommand>
    {
        private readonly IAttachmentServices _attachmentServices;
        private readonly string[] _validEntityTypes = { "MedicalReport", "Prescription", "Profile", "Message" };

        public EditAttachmentValidator(IAttachmentServices attachmentServices)
        {
            _attachmentServices = attachmentServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.AttachmentId)
                .GreaterThan(0).WithMessage("AttachmentId must be greater than 0");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.RelatedEntityType)
                .Must(type => string.IsNullOrEmpty(type) || _validEntityTypes.Contains(type))
                .WithMessage($"RelatedEntityType must be one of: {string.Join(", ", _validEntityTypes)}");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.AttachmentId)
                .MustAsync(async (attachmentId, cancellationToken) =>
                {
                    var attachment = await _attachmentServices.GetByIDAsync(attachmentId);
                    return attachment != null && !attachment.IsDeleted;
                })
                .WithMessage("Attachment does not exist");
        }
    }
}