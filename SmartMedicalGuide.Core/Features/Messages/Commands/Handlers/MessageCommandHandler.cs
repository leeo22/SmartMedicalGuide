using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Messages.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Messages.Commands.Handlers
{
    public class MessageCommandHandler : ResponseHandler,
        IRequestHandler<AddMessageCommand, Response<string>>,
        IRequestHandler<EditMessageCommand, Response<string>>,
        IRequestHandler<DeleteMessageCommand, Response<string>>
    {
        private readonly IMessageServices _messageServices;
        private readonly IChatServices _chatServices;  // ✅ أضف هذا لتحديث آخر رسالة
        private readonly IMapper _mapper;

        public MessageCommandHandler(
            IMessageServices messageServices,
            IChatServices chatServices,  // ✅ أضف هذا
            IMapper mapper)
        {
            _messageServices = messageServices;
            _chatServices = chatServices;  // ✅ أضف هذا
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            var resultMapper = _mapper.Map<Message>(request);

            // ✅ تعيين القيم الجديدة
            resultMapper.IsRead = false;
            resultMapper.SentAt = DateTime.UtcNow;
            resultMapper.IsDeleted = false;

            var result = await _messageServices.AddAsync(resultMapper);

            if (result == "Success")
            {
                // ✅ تحديث آخر رسالة في المحادثة
                var chat = await _chatServices.GetByIDAsync(request.ChatId);
                if (chat != null)
                {
                    chat.LastMessage = request.Content;
                    chat.LastMessageAt = DateTime.UtcNow;
                    await _chatServices.EditAsync(chat);
                }
            }

            return result == "Success" ? Created("Message added successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditMessageCommand request, CancellationToken cancellationToken)
        {
            var result = await _messageServices.GetByIDAsync(request.MessageId);
            if (result == null)
                return NotFound<string>("Message not found");

            // ✅ تحديث المحتوى فقط (لا يمكن تغيير الباقي)
            result.Content = request.Content ?? result.Content;

            var result1 = await _messageServices.EditAsync(result);
            return result1 == "Success" ? Success("Message edited successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var result = await _messageServices.GetByIDAsync(request.Id);
            if (result == null)
                return NotFound<string>("Message not found");

            // ✅ حذف منطقي بدلاً من حذف فعلي
            result.IsDeleted = true;
            var result1 = await _messageServices.EditAsync(result);

            return result1 == "Success"
                ? Deleted<string>($"Message deleted successfully: {request.Id}")
                : BadRequest<string>();
        }
    }
}