using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.AppointmentHistories.Commands.Models
{
    public class DeleteAppointmentHistoryCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteAppointmentHistoryCommand(int id) => Id = id;
    }
}