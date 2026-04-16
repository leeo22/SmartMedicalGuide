using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Notifications.Queries.Models;
using SmartMedicalGuide.Core.Features.Notifications.Queries.Results;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Notifications.Queries.Handlers
{
    public class NotificationQueryHandler : ResponseHandler,
        IRequestHandler<GetNotificationListQuery, Response<List<GetNotificationListResponse>>>,
        IRequestHandler<GetNotificationByIDQuery, Response<GetSingleNotificationResponse>>
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
            var resultList = await _notificationServices.GetListAsync();
            if (request.UserId.HasValue)
                resultList = resultList.Where(n => n.UserId == request.UserId.Value).ToList();
            if (request.IsRead.HasValue)
                resultList = resultList.Where(n => n.IsRead == request.IsRead.Value).ToList();
            var resultListMapper = _mapper.Map<List<GetNotificationListResponse>>(resultList);
            return Success(resultListMapper);
        }

        public async Task<Response<GetSingleNotificationResponse>> Handle(GetNotificationByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _notificationServices.GetByIDAsync(request.Id);
            if (result == null) return NotFound<GetSingleNotificationResponse>("No notification found");
            var result1 = _mapper.Map<GetSingleNotificationResponse>(result);
            return Success(result1);
        }
    }
}