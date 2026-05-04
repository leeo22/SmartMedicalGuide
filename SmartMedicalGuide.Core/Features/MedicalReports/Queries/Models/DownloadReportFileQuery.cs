using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Queries.Models
{
    public class DownloadReportFileQuery : IRequest<Response<(string filePath, string fileName, string contentType)>>
    {
        public int ReportId { get; set; }
        public DownloadReportFileQuery(int reportId) => ReportId = reportId;
    }
}