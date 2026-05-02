using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.ChatParticipants.Queries.Models;
using SmartMedicalGuide.Core.Features.ChatParticipants.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.ChatParticipants.Queries.Handlers
{
    public class ChatParticipantQueryHandler : ResponseHandler,
        IRequestHandler<GetChatParticipantsQuery, Response<List<ChatParticipantResponse>>>,
        IRequestHandler<GetUserChatsQuery, Response<List<UserChatResponse>>>
    {
        private readonly IChatParticipantServices _chatParticipantServices;
        private readonly IChatServices _chatServices;
        private readonly IMessageServices _messageServices;
        private readonly IMapper _mapper;

        public ChatParticipantQueryHandler(
            IChatParticipantServices chatParticipantServices,
            IChatServices chatServices,
            IMessageServices messageServices,
            IMapper mapper)
        {
            _chatParticipantServices = chatParticipantServices;
            _chatServices = chatServices;
            _messageServices = messageServices;
            _mapper = mapper;
        }

        public async Task<Response<List<ChatParticipantResponse>>> Handle(GetChatParticipantsQuery request, CancellationToken cancellationToken)
        {
            var chat = await _chatServices.GetByIDAsync(request.ChatId);
            if (chat == null)
                return NotFound<List<ChatParticipantResponse>>("Chat not found");

            var participants = await _chatParticipantServices.GetByChatIdAsync(request.ChatId);

            if (participants == null || !participants.Any())
                return Success(new List<ChatParticipantResponse>());

            var result = _mapper.Map<List<ChatParticipantResponse>>(participants);

            return Success(result);
        }

        public async Task<Response<List<UserChatResponse>>> Handle(GetUserChatsQuery request, CancellationToken cancellationToken)
        {
            var userParticipants = await _chatParticipantServices.GetByUserIdAsync(request.UserId);

            if (userParticipants == null || !userParticipants.Any())
                return Success(new List<UserChatResponse>());

            var result = new List<UserChatResponse>();

            foreach (var participant in userParticipants)
            {
                var chat = await _chatServices.GetByIDAsync(participant.ChatId);
                if (chat != null && chat.IsActive)
                {
                    var chatResponse = _mapper.Map<UserChatResponse>(participant);

                    var messages = await _messageServices.GetByChatIdAsync(chat.ChatId);
                    chatResponse.UnreadCount = messages.Count(m => !m.IsRead && m.SenderId != request.UserId);
                    chatResponse.LastMessage = chat.LastMessage;
                    chatResponse.LastMessageAt = chat.LastMessageAt;
                    chatResponse.ChatName = chat.ChatName;
                    chatResponse.IsGroup = chat.IsGroup;

                    result.Add(chatResponse);
                }
            }

            result = result.OrderByDescending(r => r.LastMessageAt).ToList();

            return Success(result);
        }
    }
}