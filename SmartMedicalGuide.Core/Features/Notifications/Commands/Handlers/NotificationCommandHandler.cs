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
        IRequestHandler<MarkAsReadCommand, Response<string>>,
        IRequestHandler<MarkAllAsReadCommand, Response<string>>
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
            var notification = _mapper.Map<Notification>(request);
            var result = await _notificationServices.AddAsync(notification);

            if (result != "Success")
                return BadRequest<string>(result);

            return Created("Notification added successfully");
        }

        public async Task<Response<string>> Handle(EditNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = _mapper.Map<Notification>(request);
            var result = await _notificationServices.EditAsync(notification);

            if (result == "Notification not found")
                return NotFound<string>("Notification not found");
            if (result != "Success")
                return BadRequest<string>(result);

            return Success("Notification edited successfully");
        }

        public async Task<Response<string>> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = await _notificationServices.GetByIDAsync(request.Id);
            if (notification == null)
                return NotFound<string>("Notification not found");

            var result = await _notificationServices.DeleteAsync(notification);
            return result == "Success" ? Deleted<string>("Notification deleted successfully") : BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(MarkAsReadCommand request, CancellationToken cancellationToken)
        {
            var result = await _notificationServices.MarkAsReadAsync(request.NotificationId);

            if (!result)
                return BadRequest<string>("Failed to mark notification as read");

            return Success("Notification marked as read");
        }

        public async Task<Response<string>> Handle(MarkAllAsReadCommand request, CancellationToken cancellationToken)
        {
            var result = await _notificationServices.MarkAllAsReadAsync(request.UserId);

            if (!result)
                return BadRequest<string>("Failed to mark all notifications as read");

            return Success("All notifications marked as read");
        }
    }
}