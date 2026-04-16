using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Chats.Commands.Models
{
    public class EditChatCommand : IRequest<Response<string>>
    {
        public int ChatId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}