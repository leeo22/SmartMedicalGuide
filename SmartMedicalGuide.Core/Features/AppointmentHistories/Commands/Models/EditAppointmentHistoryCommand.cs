using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.AppointmentHistories.Commands.Models
{
    public class EditAppointmentHistoryCommand : IRequest<Response<string>>
    {
        public int HistoryId { get; set; }
        public int AppointmentId { get; set; }
        public string AppointmentType { get; set; }
        public string Status { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}