using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.AppointmentHistories.Commands.Models
{
    public class AddAppointmentHistoryCommand : IRequest<Response<string>>
    {
        public int AppointmentId { get; set; }
        public string AppointmentType { get; set; } // "Doctor" or "Lab"
        public string Status { get; set; }
        public DateTime ChangedAt { get; set; } = DateTime.Now;
    }
}