using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Chats.Commands.Models;
using SmartMedicalGuide.Core.Features.Chats.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [ApiController]
    [Authorize]
    public class ChatController : AppControllerBase
    {
        [SwaggerOperation(Summary = "إنشاء محادثة جديدة", OperationId = "CreateChat")]
        [HttpPost(Router.ChatRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddChatCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "تعديل محادثة", OperationId = "EditChat")]
        [HttpPut(Router.ChatRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditChatCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "حذف محادثة", OperationId = "DeleteChat")]
        [HttpDelete(Router.ChatRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteChatCommand(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "جلب جميع المحادثات", OperationId = "GetChatList")]
        [HttpGet(Router.ChatRouting.List)]
        public async Task<IActionResult> GetChatList([FromQuery] int? patientId, [FromQuery] int? doctorId)
        {
            var response = await Mediator.Send(new GetChatListQuery(patientId, doctorId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "جلب محادثة بواسطة ID", OperationId = "GetChatById")]
        [HttpGet(Router.ChatRouting.GetById)]
        public async Task<IActionResult> GetChatById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetChatByIDQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "جلب محادثة بين مريض وطبيب", OperationId = "GetChatByPatientAndDoctor")]
        [HttpGet(Router.ChatRouting.GetByPatientDoctor)]
        public async Task<IActionResult> GetChatByPatientAndDoctor([FromQuery] int patientId, [FromQuery] int doctorId)
        {
            var response = await Mediator.Send(new GetChatByPatientDoctorQuery(patientId, doctorId));
            return NewResult(response);
        }
    }
}