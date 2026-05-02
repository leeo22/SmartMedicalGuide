using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.ChatParticipants.Commands.Models;
using SmartMedicalGuide.Core.Features.ChatParticipants.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [ApiController]
    [Authorize]
    public class ChatParticipantController : AppControllerBase
    {
        [SwaggerOperation(Summary = "إضافة مشارك جديد للمحادثة", OperationId = "AddParticipantToChat")]
        [HttpPost(Router.ChatParticipantRouting.AddParticipant)]
        public async Task<IActionResult> AddParticipant([FromBody] AddParticipantToChatCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "إزالة مشارك من المحادثة", OperationId = "RemoveParticipantFromChat")]
        [HttpDelete(Router.ChatParticipantRouting.RemoveParticipant)]
        public async Task<IActionResult> RemoveParticipant([FromBody] RemoveParticipantFromChatCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "تحديث حالة الكتابة", OperationId = "UpdateTypingStatus")]
        [HttpPut(Router.ChatParticipantRouting.UpdateTypingStatus)]
        public async Task<IActionResult> UpdateTypingStatus([FromBody] UpdateTypingStatusCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "جلب جميع المشاركين في محادثة", OperationId = "GetChatParticipants")]
        [HttpGet(Router.ChatParticipantRouting.GetByChatId)]
        public async Task<IActionResult> GetChatParticipants([FromRoute] int chatId)
        {
            var response = await Mediator.Send(new GetChatParticipantsQuery(chatId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "جلب جميع محادثات المستخدم", OperationId = "GetUserChats")]
        [HttpGet(Router.ChatParticipantRouting.GetUserChats)]
        public async Task<IActionResult> GetUserChats([FromRoute] int userId)
        {
            var response = await Mediator.Send(new GetUserChatsQuery(userId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "جلب محادثات المستخدم الحالي", OperationId = "GetMyChats")]
        [HttpGet(Router.ChatParticipantRouting.GetMyChats)]
        public async Task<IActionResult> GetMyChats()
        {
            // استخدم الـ Claim من التوكن
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userIdClaim, out int userId))
            {
                var response = await Mediator.Send(new GetUserChatsQuery(userId));
                return NewResult(response);
            }
            return Unauthorized();
        }
    }
}