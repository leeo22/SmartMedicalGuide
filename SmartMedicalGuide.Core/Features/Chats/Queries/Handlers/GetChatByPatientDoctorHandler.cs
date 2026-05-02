using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Chats.Queries.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Chats.Queries.Handlers
{
    public class GetChatByPatientDoctorHandler : ResponseHandler, IRequestHandler<GetChatByPatientDoctorQuery, Response<Chat>>
    {
        private readonly IChatServices _chatServices;

        public GetChatByPatientDoctorHandler(IChatServices chatServices)
        {
            _chatServices = chatServices;
        }

        public async Task<Response<Chat>> Handle(GetChatByPatientDoctorQuery request, CancellationToken cancellationToken)
        {
            var chat = await _chatServices.GetByPatientAndDoctorAsync(request.PatientId, request.DoctorId);
            if (chat == null)
                return NotFound<Chat>("No chat found between this patient and doctor");

            return Success(chat);
        }
    }
}