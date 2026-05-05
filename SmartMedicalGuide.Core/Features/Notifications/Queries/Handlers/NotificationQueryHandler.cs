using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Notifications.Queries.Models;
using SmartMedicalGuide.Core.Features.Notifications.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Notifications.Queries.Handlers
{
    public class NotificationQueryHandler : ResponseHandler,
        IRequestHandler<GetNotificationListQuery, Response<List<GetNotificationListResponse>>>,
        IRequestHandler<GetNotificationByIdQuery, Response<GetSingleNotificationResponse>>,
        IRequestHandler<GetUnreadCountQuery, Response<int>>
    {
        private readonly INotificationServices _notificationServices;
        private readonly IMapper _mapper;

        public NotificationQueryHandler(INotificationServices notificationServices, IMapper mapper)
        {
            _notificationServices = notificationServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetNotificationListResponse>>> Handle(GetNotificationListQuery request, CancellationToken cancellationToken)
        {
            List<Notification> notifications;

            if (request.UserId.HasValue)
            {
                if (request.IsRead.HasValue)
                {
                    notifications = request.IsRead.Value
                        ? await _notificationServices.GetByUserIdAsync(request.UserId.Value)
                        : await _notificationServices.GetUnreadByUserIdAsync(request.UserId.Value);
                }
                else
                {
                    notifications = await _notificationServices.GetByUserIdAsync(request.UserId.Value);
                }
            }
            else
            {
                notifications = await _notificationServices.GetListAsync();
            }

            if (!string.IsNullOrWhiteSpace(request.NotificationType))
            {
                notifications = notifications.Where(x => x.NotificationType == request.NotificationType).ToList();
            }

            var result = _mapper.Map<List<GetNotificationListResponse>>(notifications);
            return Success(result);
        }

        public async Task<Response<GetSingleNotificationResponse>> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            var notification = await _notificationServices.GetByIDAsync(request.Id);
            if (notification == null)
                return NotFound<GetSingleNotificationResponse>("Notification not found");

            var result = _mapper.Map<GetSingleNotificationResponse>(notification);
            return Success(result);
        }

        public async Task<Response<int>> Handle(GetUnreadCountQuery request, CancellationToken cancellationToken)
        {
            var count = await _notificationServices.GetUnreadCountAsync(request.UserId);
            return Success(count);
        }
    }
}