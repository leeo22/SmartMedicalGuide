using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Prescriptions.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Prescriptions.Queries.Models
{
    public class GetPrescriptionListQuery : IRequest<Response<List<GetPrescriptionListResponse>>>
    {
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? DoctorAppointmentId { get; set; }
        public GetPrescriptionListQuery() { }
        public GetPrescriptionListQuery(int? patientId, int? doctorId, int? doctorAppointmentId)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            DoctorAppointmentId = doctorAppointmentId;
        }
    }
}