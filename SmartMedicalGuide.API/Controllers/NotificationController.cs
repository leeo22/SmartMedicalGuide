using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Notifications.Commands.Models;
using SmartMedicalGuide.Core.Features.Notifications.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
    
    [ApiController]
    public class NotificationController : AppControllerBase
    {
        [HttpGet(Router.NotificationRouting.List)]
        public async Task<IActionResult> GetNotificationList()
        {
            var response = await Mediator.Send(new GetNotificationListQuery());
            return Ok(response);
        }

        [HttpPost(Router.NotificationRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddNotificationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.NotificationRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditNotificationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.NotificationRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteNotificationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.NotificationRouting.GetByID)]
        public async Task<IActionResult> GetNotificationByID([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetNotificationByIDQuery(id));
            return Ok(response);
        }

    }
}
