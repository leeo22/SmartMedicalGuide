using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Chats.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Chats.Queries.Models
{
    public class GetChatListQuery : IRequest<Response<List<GetChatListResponse>>>
    {
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public GetChatListQuery() { }
        public GetChatListQuery(int? patientId, int? doctorId)
        {
            PatientId = patientId;
            DoctorId = doctorId;
        }
    }
}