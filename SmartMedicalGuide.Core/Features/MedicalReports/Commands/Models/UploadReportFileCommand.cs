using MediatR;
using Microsoft.AspNetCore.Http;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Commands.Models
{
    public class UploadReportFileCommand : IRequest<Response<string>>
    {
        public int ReportId { get; set; }
        public IFormFile File { get; set; }
    }
}