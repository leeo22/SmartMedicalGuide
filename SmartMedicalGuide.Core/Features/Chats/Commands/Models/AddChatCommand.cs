using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Chats.Commands.Models
{
    public class AddChatCommand : IRequest<Response<string>>
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // ✅ الحقول الجديدة
        public string ChatName { get; set; }  // اسم المحادثة
        public bool IsGroup { get; set; } = false;  // هل هي جماعية؟
        public bool IsActive { get; set; } = true;  // هل المحادثة نشطة؟
    }
}