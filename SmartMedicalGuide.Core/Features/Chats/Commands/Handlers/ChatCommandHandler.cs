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
        private readonly IChatParticipantServices _chatParticipantServices;  // ✅ أضف هذا
        private readonly IMapper _mapper;

        public ChatCommandHandler(
            IChatServices chatServices,
            IChatParticipantServices chatParticipantServices,  // ✅ أضف هذا
            IMapper mapper)
        {
            _chatServices = chatServices;
            _chatParticipantServices = chatParticipantServices;  // ✅ أضف هذا
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddChatCommand request, CancellationToken cancellationToken)
        {
            // التحقق من وجود محادثة بين same patient and doctor
            var existingChat = await _chatServices.GetByPatientAndDoctorAsync(request.PatientId, request.DoctorId);
            if (existingChat != null)
                return BadRequest<string>("Chat already exists between this patient and doctor");

            // إنشاء المحادثة
            var resultMapper = _mapper.Map<Chat>(request);

            // ✅ تعيين القيم الجديدة
            resultMapper.ChatName = request.ChatName ?? $"Chat between Patient {request.PatientId} and Doctor {request.DoctorId}";
            resultMapper.IsGroup = request.IsGroup;
            resultMapper.IsActive = true;
            resultMapper.CreatedAt = DateTime.UtcNow;

            var result = await _chatServices.AddAsync(resultMapper);

            if (result == "Success")
            {
                // ✅ إضافة المشاركين إلى ChatParticipants
                // إضافة المريض كمشارك
                await _chatParticipantServices.AddUserToChatAsync(resultMapper.ChatId, request.PatientId, isAdmin: false);
                // إضافة الدكتور كمشارك
                await _chatParticipantServices.AddUserToChatAsync(resultMapper.ChatId, request.DoctorId, isAdmin: false);
            }

            return result == "Success" ? Created("Chat added successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditChatCommand request, CancellationToken cancellationToken)
        {
            var result = await _chatServices.GetByIDAsync(request.ChatId);
            if (result == null)
                return NotFound<string>("Chat not found");

            // ✅ تحديث الحقول الجديدة
            result.ChatName = request.ChatName ?? result.ChatName;
            result.IsGroup = request.IsGroup;
            result.IsActive = request.IsActive;

            var result1 = await _chatServices.EditAsync(result);
            return result1 == "Success" ? Success("Chat edited successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteChatCommand request, CancellationToken cancellationToken)
        {
            var result = await _chatServices.GetByIDAsync(request.Id);
            if (result == null)
                return NotFound<string>("Chat not found");

            // ✅ حذف منطقي بدلاً من حذف فعلي (اختياري)
            result.IsActive = false;
            await _chatServices.EditAsync(result);

            // ✅ أو حذف فعلي مع حذف المشاركات
            // var result1 = await _chatServices.DeleteAsync(result);

            return Deleted<string>($"Chat deleted successfully: {request.Id}");
        }
    }
}