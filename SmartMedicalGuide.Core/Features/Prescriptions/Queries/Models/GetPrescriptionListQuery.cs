using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Prescriptions.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Queries.Models
{
    public class GetPrescriptionListQuery : IRequest<Response<List<GetPrescriptionListResponse>>>
    {
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? AppointmentId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Status { get; set; }
    }
}