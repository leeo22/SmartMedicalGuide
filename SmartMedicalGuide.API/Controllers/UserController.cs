using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Users.Commands.Models;
using SmartMedicalGuide.Core.Features.Users.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AppControllerBase
    {
        [HttpGet(Router.UserRouting.List)]
        public async Task<IActionResult> GetUserList()
        {
            var response = await Mediator.Send(new GetUserListQuery());
            return Ok(response);
        }
        [HttpGet(Router.UserRouting.GetByID)]
        public async Task<IActionResult> GetUserByID([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetUserByIDQuery(id));
            return Ok(response);
        }
        [HttpPost(Router.UserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.UserRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.UserRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

    }
}
