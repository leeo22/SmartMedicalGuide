using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Chats.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Chats.Commands.Handlers
{
    public class ChatCommandHandler : ResponseHandler,
        IRequestHandler<AddChatCommand, Response<string>>,
        IRequestHandler<EditChatCommand, Response<string>>,
        IRequestHandler<DeleteChatCommand, Response<string>>
    {
        private readonly IChatServices _chatServices;
        private readonly IMapper _mapper;

        public ChatCommandHandler(IChatServices chatServices, IMapper mapper)
        {
            _chatServices = chatServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddChatCommand request, CancellationToken cancellationToken)
        {
            var existingChat = await _chatServices.GetByPatientAndDoctorAsync(request.PatientId, request.DoctorId);
            if (existingChat != null) return BadRequest<string>("Chat already exists between this patient and doctor");

            var resultMapper = _mapper.Map<Chat>(request);
            var result = await _chatServices.AddAsync(resultMapper);
            return result == "Success" ? Created("Chat added successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditChatCommand request, CancellationToken cancellationToken)
        {
            var result = await _chatServices.GetByIDAsync(request.ChatId);
            if (result == null) return NotFound<string>("Chat not found");
            var resultMapper = _mapper.Map<Chat>(request);
            var result1 = await _chatServices.EditAsync(resultMapper);
            return result1 == "Success" ? Success("Chat edited successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteChatCommand request, CancellationToken cancellationToken)
        {
            var result = await _chatServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<string>("Chat not found");
            var result1 = await _chatServices.DeleteAsync(result);
            return result1 == "Success" ? Deleted<string>($"Chat deleted successfully: {request.Id}") : BadRequest<string>();
        }
    }
}