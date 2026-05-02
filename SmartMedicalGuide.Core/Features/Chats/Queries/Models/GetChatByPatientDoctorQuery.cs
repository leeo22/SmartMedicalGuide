using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Data.Entities;

namespace SmartMedicalGuide.Core.Features.Chats.Queries.Models
{
    public class GetChatByPatientDoctorQuery : IRequest<Response<Chat>>
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public GetChatByPatientDoctorQuery(int patientId, int doctorId)
        {
            PatientId = patientId;
            DoctorId = doctorId;
        }
    }
}