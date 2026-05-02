using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Chats.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Chats.Queries.Models
{
    public class GetChatListQuery : IRequest<Response<List<GetChatListResponse>>>
    {
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? CurrentUserId { get; set; }  // ✅ أضف هذا لحساب الرسائل غير المقروءة

        public GetChatListQuery() { }

        public GetChatListQuery(int? patientId, int? doctorId, int? currentUserId = null)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            CurrentUserId = currentUserId;
        }
    }
}