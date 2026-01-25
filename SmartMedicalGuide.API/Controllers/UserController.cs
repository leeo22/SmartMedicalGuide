using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Users.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{

    [ApiController]
    public class UserController : AppControllerBase
    {
        [HttpGet(Router.UserRouting.List)]
        public async Task<IActionResult> GetUserList()
        {
            var response = await Mediator.Send(new GetUserListQuery());
            return Ok(response);
        }
    }
}
