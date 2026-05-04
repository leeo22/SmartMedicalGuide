using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Notifications.Commands.Models;
using SmartMedicalGuide.Core.Features.Notifications.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class NotificationController : AppControllerBase
    {
        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(userIdClaim, out int userId) ? userId : 0;
        }

        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all notifications", OperationId = "GetAllNotifications")]
        [HttpGet(Router.NotificationRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] int? userId, [FromQuery] bool? isRead, [FromQuery] string? notificationType)
        {
            var response = await Mediator.Send(new GetNotificationListQuery
            {
                UserId = userId,
                IsRead = isRead,
                NotificationType = notificationType
            });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get notification by ID", OperationId = "GetNotificationById")]
        [HttpGet(Router.NotificationRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetNotificationByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new notification", OperationId = "CreateNotification")]
        [HttpPost(Router.NotificationRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddNotificationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update notification", OperationId = "UpdateNotification")]
        [HttpPut(Router.NotificationRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditNotificationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete notification", OperationId = "DeleteNotification")]
        [HttpDelete(Router.NotificationRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteNotificationCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Important Endpoints
        [SwaggerOperation(Summary = "Get my notifications", OperationId = "GetMyNotifications")]
        [HttpGet(Router.NotificationRouting.GetMyNotifications)]
        public async Task<IActionResult> GetMyNotifications([FromQuery] bool? isRead)
        {
            var userId = GetCurrentUserId();
            if (userId == 0)
                return Unauthorized();

            var response = await Mediator.Send(new GetNotificationListQuery
            {
                UserId = userId,
                IsRead = isRead
            });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get my unread notifications", OperationId = "GetMyUnreadNotifications")]
        [HttpGet(Router.NotificationRouting.GetMyUnread)]
        public async Task<IActionResult> GetMyUnread()
        {
            var userId = GetCurrentUserId();
            if (userId == 0)
                return Unauthorized();

            var response = await Mediator.Send(new GetNotificationListQuery
            {
                UserId = userId,
                IsRead = false
            });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get my unread count", OperationId = "GetMyUnreadCount")]
        [HttpGet(Router.NotificationRouting.GetUnreadCount)]
        public async Task<IActionResult> GetMyUnreadCount()
        {
            var userId = GetCurrentUserId();
            if (userId == 0)
                return Unauthorized();

            var response = await Mediator.Send(new GetUnreadCountQuery { UserId = userId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Mark notification as read", OperationId = "MarkAsRead")]
        [HttpPut(Router.NotificationRouting.MarkAsRead)]
        public async Task<IActionResult> MarkAsRead([FromBody] MarkAsReadCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Mark all my notifications as read", OperationId = "MarkAllAsRead")]
        [HttpPut(Router.NotificationRouting.MarkAllAsRead)]
        public async Task<IActionResult> MarkAllAsRead()
        {
            var userId = GetCurrentUserId();
            if (userId == 0)
                return Unauthorized();

            var response = await Mediator.Send(new MarkAllAsReadCommand { UserId = userId });
            return NewResult(response);
        }
        #endregion
    }
}