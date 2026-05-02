using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Messages.Commands.Models;
using SmartMedicalGuide.Core.Features.Messages.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [ApiController]
    [Authorize]
    public class MessageController : AppControllerBase
    {
        [SwaggerOperation(Summary = "إضافة رسالة جديدة", OperationId = "AddMessage")]
        [HttpPost(Router.MessageRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddMessageCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "تعديل رسالة", OperationId = "EditMessage")]
        [HttpPut(Router.MessageRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditMessageCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "حذف رسالة", OperationId = "DeleteMessage")]
        [HttpDelete(Router.MessageRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteMessageCommand(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "جلب جميع الرسائل", OperationId = "GetMessageList")]
        [HttpGet(Router.MessageRouting.List)]
        public async Task<IActionResult> GetMessageList([FromQuery] int? chatId, [FromQuery] int? senderId)
        {
            var response = await Mediator.Send(new GetMessageListQuery(chatId, senderId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "جلب رسالة بواسطة ID", OperationId = "GetMessageById")]
        [HttpGet(Router.MessageRouting.GetById)]
        public async Task<IActionResult> GetMessageById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetMessageByIDQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "جلب رسائل محادثة معينة", OperationId = "GetMessagesByChatId")]
        [HttpGet(Router.MessageRouting.GetByChatId)]
        public async Task<IActionResult> GetMessagesByChatId([FromRoute] int chatId)
        {
            var response = await Mediator.Send(new GetMessageListQuery(chatId, null));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "تحديد قراءة رسالة", OperationId = "MarkMessageAsRead")]
        [HttpPut(Router.MessageRouting.MarkAsRead)]
        public async Task<IActionResult> MarkMessageAsRead([FromRoute] int id)
        {
            var response = await Mediator.Send(new EditMessageCommand { MessageId = id, IsRead = true });
            return NewResult(response);
        }
    }
}