using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.AppointmentHistories.Queries.Results;

namespace SmartMedicalGuide.Core.Features.AppointmentHistories.Queries.Models
{
    public class GetAppointmentHistoryListQuery : IRequest<Response<List<GetAppointmentHistoryListResponse>>>
    {
        public int? AppointmentId { get; set; }
        public string? AppointmentType { get; set; }
        public GetAppointmentHistoryListQuery() { }
        public GetAppointmentHistoryListQuery(int? appointmentId, string? appointmentType)
        {
            AppointmentId = appointmentId;
            AppointmentType = appointmentType;
        }
    }
}