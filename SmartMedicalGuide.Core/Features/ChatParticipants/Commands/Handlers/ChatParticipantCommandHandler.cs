using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.ChatParticipants.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.ChatParticipants.Commands.Handlers
{
    public class ChatParticipantCommandHandler : ResponseHandler,
        IRequestHandler<AddParticipantToChatCommand, Response<string>>,
        IRequestHandler<RemoveParticipantFromChatCommand, Response<string>>,
        IRequestHandler<UpdateTypingStatusCommand, Response<string>>
    {
        private readonly IChatParticipantServices _chatParticipantServices;
        private readonly IChatServices _chatServices;
        private readonly IMapper _mapper;

        public ChatParticipantCommandHandler(
            IChatParticipantServices chatParticipantServices,
            IChatServices chatServices,
            IMapper mapper)
        {
            _chatParticipantServices = chatParticipantServices;
            _chatServices = chatServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddParticipantToChatCommand request, CancellationToken cancellationToken)
        {
            var chat = await _chatServices.GetByIDAsync(request.ChatId);
            if (chat == null)
                return NotFound<string>("Chat not found");

            var isExist = await _chatParticipantServices.IsUserInChatAsync(request.ChatId, request.UserId);
            if (isExist)
                return BadRequest<string>("User is already a participant in this chat");

            var participant = new ChatParticipant
            {
                ChatId = request.ChatId,
                UserId = request.UserId,
                JoinedAt = DateTime.UtcNow,
                IsAdmin = request.IsAdmin
            };

            var result = await _chatParticipantServices.AddAsync(participant);

            return result == "Success"
                ? Created("Participant added successfully")
                : BadRequest<string>("Failed to add participant");
        }

        public async Task<Response<string>> Handle(RemoveParticipantFromChatCommand request, CancellationToken cancellationToken)
        {
            var chat = await _chatServices.GetByIDAsync(request.ChatId);
            if (chat == null)
                return NotFound<string>("Chat not found");

            var participant = await _chatParticipantServices.GetParticipantAsync(request.ChatId, request.UserId);
            if (participant == null)
                return NotFound<string>("Participant not found");

            var result = await _chatParticipantServices.DeleteAsync(participant);

            return result == "Success"
                ? Success("Participant removed successfully")
                : BadRequest<string>("Failed to remove participant");
        }

        public async Task<Response<string>> Handle(UpdateTypingStatusCommand request, CancellationToken cancellationToken)
        {
            var chat = await _chatServices.GetByIDAsync(request.ChatId);
            if (chat == null)
                return NotFound<string>("Chat not found");

            await _chatParticipantServices.UpdateTypingStatusAsync(request.ChatId, request.UserId, request.IsTyping);

            return Success(request.IsTyping ? "User is typing" : "User stopped typing");
        }
    }
}