using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Commands.Models
{
    public class EditMedicalReportCommand : IRequest<Response<string>>
    {
        public int ReportId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int LabId { get; set; }
        public string FilePath { get; set; }
        public string ReportType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}