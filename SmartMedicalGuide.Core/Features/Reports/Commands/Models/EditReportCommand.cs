using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Reports.Commands.Models
{
    public class EditReportCommand : IRequest<Response<string>>
    {
        public int ReportId { get; set; }

        public int ReporterUserId { get; set; }

        public string? TargetType { get; set; }
        public int TargetId { get; set; }

        public string? Reason { get; set; }
        public string? Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
