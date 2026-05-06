using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.LabAppointments.Queries.Results;

namespace SmartMedicalGuide.Core.Features.LabAppointments.Queries.Models
{
    public class GetLabAppointmentListQuery : IRequest<Response<List<GetLabAppointmentListResponse>>>
    {
        public int? LabId { get; set; }
        public int? PatientId { get; set; }
        public string? Status { get; set; }
        public DateTime? Date { get; set; }
        public bool? Upcoming { get; set; }
    }
}