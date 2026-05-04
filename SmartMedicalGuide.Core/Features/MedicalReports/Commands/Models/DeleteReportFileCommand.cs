using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Commands.Models
{
    public class DeleteReportFileCommand : IRequest<Response<string>>
    {
        public int ReportId { get; set; }
        public DeleteReportFileCommand(int reportId) => ReportId = reportId;
    }
}