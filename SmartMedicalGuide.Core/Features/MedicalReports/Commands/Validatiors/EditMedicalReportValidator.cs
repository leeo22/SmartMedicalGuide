using FluentValidation;
using SmartMedicalGuide.Core.Features.MedicalReports.Commands.Models;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Commands.Validators
{
    public class EditMedicalReportValidator : AbstractValidator<EditMedicalReportCommand>
    {
        private readonly IMedicalReportServices _reportServices;

        public EditMedicalReportValidator(IMedicalReportServices reportServices)
        {
            _reportServices = reportServices;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.ReportId)
                .GreaterThan(0).WithMessage("ReportId must be greater than 0");

            RuleFor(x => x.ReportDate)
                .NotNull().WithMessage("Report date is required")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Report date cannot be in the future");

            RuleFor(x => x.ReportType)
                .MaximumLength(100).WithMessage("Report type cannot exceed 100 characters");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("Description cannot exceed 2000 characters");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.ReportId)
                .MustAsync(async (reportId, cancellationToken) =>
                {
                    var report = await _reportServices.GetByIDAsync(reportId);
                    return report != null && !report.IsDeleted;
                })
                .WithMessage("Report does not exist");
        }
    }
}