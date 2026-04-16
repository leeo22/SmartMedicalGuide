using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.MedicalReports.Queries.Results;

namespace SmartMedicalGuide.Core.Features.MedicalReports.Queries.Models
{
    public class GetMedicalReportListQuery : IRequest<Response<List<GetMedicalReportListResponse>>>
    {
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? LabId { get; set; }
        public GetMedicalReportListQuery() { }
        public GetMedicalReportListQuery(int? patientId, int? doctorId, int? labId)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            LabId = labId;
        }
    }
}