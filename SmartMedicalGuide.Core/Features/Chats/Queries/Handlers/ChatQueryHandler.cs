using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Chats.Queries.Models;
using SmartMedicalGuide.Core.Features.Chats.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Chats.Queries.Handlers
{
    public class ChatQueryHandler : ResponseHandler,
        IRequestHandler<GetChatListQuery, Response<List<GetChatListResponse>>>,
        IRequestHandler<GetChatByIDQuery, Response<GetSingleChatResponse>>
    {
        private readonly IChatServices _chatServices;
        private readonly IMessageServices _messageServices;  // ✅ أضف هذا
        private readonly IChatParticipantServices _chatParticipantServices;  // ✅ أضف هذا
        private readonly IMapper _mapper;

        public ChatQueryHandler(
            IChatServices chatServices,
            IMessageServices messageServices,  // ✅ أضف هذا
            IChatParticipantServices chatParticipantServices,  // ✅ أضف هذا
            IMapper mapper)
        {
            _chatServices = chatServices;
            _messageServices = messageServices;
            _chatParticipantServices = chatParticipantServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetChatListResponse>>> Handle(GetChatListQuery request, CancellationToken cancellationToken)
        {
            var resultList = await _chatServices.GetListAsync();

            if (request.PatientId.HasValue)
                resultList = resultList.Where(c => c.PatientId == request.PatientId.Value).ToList();
            if (request.DoctorId.HasValue)
                resultList = resultList.Where(c => c.DoctorId == request.DoctorId.Value).ToList();

            // ✅ تصفية المحادثات النشطة فقط
            resultList = resultList.Where(c => c.IsActive).ToList();

            var resultListMapper = _mapper.Map<List<GetChatListResponse>>(resultList);

            // ✅ حساب عدد الرسائل غير المقروءة لكل محادثة (إذا كان هناك مستخدم محدد)
            if (request.CurrentUserId.HasValue)
            {
                foreach (var chat in resultListMapper)
                {
                    var messages = await _messageServices.GetByChatIdAsync(chat.ChatId);
                    chat.UnreadCount = messages.Count(m => !m.IsRead && m.SenderId != request.CurrentUserId.Value);
                }
            }

            return Success(resultListMapper);
        }

        public async Task<Response<GetSingleChatResponse>> Handle(GetChatByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _chatServices.GetByIDAsync(request.Id);
            if (result == null)
                return NotFound<GetSingleChatResponse>("No chat found");

            var result1 = _mapper.Map<GetSingleChatResponse>(result);

            // ✅ إضافة المشاركين
            var participants = await _chatParticipantServices.GetByChatIdAsync(request.Id);
            result1.Participants = _mapper.Map<List<ChatParticipantsDto>>(participants);

            // ✅ تحديث الرسائل لتشمل الحقول الجديدة
            if (result1.Messages != null)
            {
                foreach (var msg in result1.Messages)
                {
                    var fullMessage = await _messageServices.GetByIDAsync(msg.MessageId);
                    if (fullMessage != null)
                    {
                        msg.IsRead = fullMessage.IsRead;
                        msg.ReadAt = fullMessage.ReadAt;
                        msg.ReplyToMessageId = fullMessage.ReplyToMessageId;
                        msg.AttachmentUrl = fullMessage.AttachmentUrl;
                        msg.IsDeleted = fullMessage.IsDeleted;
                    }
                }
            }

            return Success(result1);
        }
    }
}