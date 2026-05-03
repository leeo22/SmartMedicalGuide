//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using SmartMedicalGuide.API.Base;
//using SmartMedicalGuide.Data.AppMetaData;

//namespace SmartMedicalGuide.API.Controllers
//{

//    [ApiController]
//    public class UserSessionController : AppControllerBase
//    {
//        [HttpGet(Router.UserSessionRouting.List)]
//        public async Task<IActionResult> GetUserSessionList()
//        {
//            var response = await Mediator.Send(new GetUserSessionListQuery());
//            return Ok(response);
//        }

//        [HttpPost(Router.UserSessionRouting.Create)]
//        public async Task<IActionResult> Create([FromBody] AddUserSessionCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpPut(Router.UserSessionRouting.Edit)]
//        public async Task<IActionResult> Edit([FromBody] EditUserSessionCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpDelete(Router.UserSessionRouting.Delete)]
//        public async Task<IActionResult> Delete([FromBody] DeleteUserSessionCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpGet(Router.UserSessionRouting.GetByID)]
//        public async Task<IActionResult> GetUserSessionByID([FromRoute] int id)
//        {
//            var response = await Mediator.Send(new GetUserSessionByIDQuery(id));
//            return Ok(response);
//        }

//delete

//    }
//}
