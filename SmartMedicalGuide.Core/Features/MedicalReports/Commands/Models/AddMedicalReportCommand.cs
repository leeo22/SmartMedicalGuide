using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Commands.Models
{
    public class AddMedicalReportCommand : IRequest<Response<string>>
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string? ReportType { get; set; }
        public string? Description { get; set; }
        public DateTime ReportDate { get; set; } = DateTime.UtcNow;
    }
}