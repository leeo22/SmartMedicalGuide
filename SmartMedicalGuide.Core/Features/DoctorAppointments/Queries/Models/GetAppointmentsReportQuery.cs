using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Models
{
    public class GetAppointmentsReportQuery : IRequest<Response<object>>
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}