using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Commands.Models
{
    public class EditMedicalReportCommand : IRequest<Response<string>>
    {
        public int ReportId { get; set; }
        public string? ReportType { get; set; }
        public string? Description { get; set; }
        public DateTime ReportDate { get; set; }
    }
}