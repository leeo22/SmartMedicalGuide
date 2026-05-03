//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using SmartMedicalGuide.API.Base;
//using SmartMedicalGuide.Core.Features.UserRefreshTokens.Commands.Models;
//using SmartMedicalGuide.Core.Features.UserRefreshTokens.Queries.Models;
//using SmartMedicalGuide.Data.AppMetaData;

//namespace SmartMedicalGuide.API.Controllers
//{
    
//    [ApiController]
//    public class UserRefreshTokenController : AppControllerBase
//    {
//        [HttpGet(Router.UserRefreshTokenRouting.List)]
//        public async Task<IActionResult> GetUserRefreshTokenList()
//        {
//            var response = await Mediator.Send(new GetUserRefreshTokenListQuery());
//            return Ok(response);
//        }

//        [HttpPost(Router.UserRefreshTokenRouting.Create)]
//        public async Task<IActionResult> Create([FromBody] AddUserRefreshTokenCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpPut(Router.UserRefreshTokenRouting.Edit)]
//        public async Task<IActionResult> Edit([FromBody] EditUserRefreshTokenCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpDelete(Router.UserRefreshTokenRouting.Delete)]
//        public async Task<IActionResult> Delete([FromBody] DeleteUserRefreshTokenCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpGet(Router.UserRefreshTokenRouting.GetByID)]
//        public async Task<IActionResult> GetUserRefreshTokenByID([FromRoute] int id)
//        {
//            var response = await Mediator.Send(new GetUserRefreshTokenByIDQuery(id));
//            return Ok(response);
//        }



//    }
//}
