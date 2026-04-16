using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Notifications.Commands.Models;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Notifications.Commands.Handlers
{
    public class NotificationCommandHandler : ResponseHandler,
        IRequestHandler<AddNotificationCommand, Response<string>>,
        IRequestHandler<EditNotificationCommand, Response<string>>,
        IRequestHandler<DeleteNotificationCommand, Response<string>>,
        IRequestHandler<MarkNotificationAsReadCommand, Response<string>>
    {
        private readonly INotificationServices _notificationServices;
        private readonly IMapper _mapper;

        public NotificationCommandHandler(INotificationServices notificationServices, IMapper mapper)
        {
            _notificationServices = notificationServices;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
        {
            var resultMapper = _mapper.Map<Notification>(request);
            var result = await _notificationServices.AddAsync(resultMapper);
            return result == "Success" ? Created("Notification added successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditNotificationCommand request, CancellationToken cancellationToken)
        {
            var result = await _notificationServices.GetByIDAsync(request.NotificationId);
            if (result == null) return NotFound<string>("Notification not found");
            var resultMapper = _mapper.Map<Notification>(request);
            var result1 = await _notificationServices.EditAsync(resultMapper);
            return result1 == "Success" ? Success("Notification edited successfully") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var result = await _notificationServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<string>("Notification not found");
            var result1 = await _notificationServices.DeleteAsync(result);
            return result1 == "Success" ? Deleted<string>($"Notification deleted successfully: {request.Id}") : BadRequest<string>();
        }

        public async Task<Response<string>> Handle(MarkNotificationAsReadCommand request, CancellationToken cancellationToken)
        {
            var result = await _notificationServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<string>("Notification not found");
            result.IsRead = true;
            var result1 = await _notificationServices.EditAsync(result);
            return result1 == "Success" ? Success("Notification marked as read") : BadRequest<string>();
        }
    }
}