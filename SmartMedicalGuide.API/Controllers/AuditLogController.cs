//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using SmartMedicalGuide.API.Base;
//using SmartMedicalGuide.Core.Features.AuditLogs.Commands.Models;
//using SmartMedicalGuide.Core.Features.AuditLogs.Queries.Models;
//using SmartMedicalGuide.Data.AppMetaData;

//namespace SmartMedicalGuide.API.Controllers
//{

//    [ApiController]
//    public class AuditLogController : AppControllerBase
//    {
//        [HttpGet(Router.AuditLogRouting.List)]
//        public async Task<IActionResult> GetAuditLogList()
//        {
//            var response = await Mediator.Send(new GetAuditLogListQuery());
//            return Ok(response);
//        }

//        [HttpPost(Router.AuditLogRouting.Create)]
//        public async Task<IActionResult> Create([FromBody] AddAuditLogCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpPut(Router.AuditLogRouting.Edit)]
//        public async Task<IActionResult> Edit([FromBody] EditAuditLogCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpDelete(Router.AuditLogRouting.Delete)]
//        public async Task<IActionResult> Delete([FromBody] DeleteAuditLogCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpGet(Router.AuditLogRouting.GetByID)]
//        public async Task<IActionResult> GetAuditLogByID([FromRoute] int id)
//        {
//            var response = await Mediator.Send(new GetAuditLogByIDQuery(id));
//            return Ok(response);
//        }

//    }
//}
