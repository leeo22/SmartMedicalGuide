//using Microsoft.AspNetCore.Mvc;
//using SmartMedicalGuide.API.Base;
//using SmartMedicalGuide.Core.Features.Roles.Commands.Models;
//using SmartMedicalGuide.Core.Features.Roles.Queries.Models;
//using SmartMedicalGuide.Data.AppMetaData;

//namespace SmartMedicalGuide.API.Controllers
//{

//    [ApiController]
//    public class RoleController : AppControllerBase
//    {
//        [HttpGet(Router.RoleRouting.List)]
//        public async Task<IActionResult> GetRoleList()
//        {
//            var response = await Mediator.Send(new GetAllRoleQuery());
//            return Ok(response);
//        }
//        [HttpGet(Router.RoleRouting.GetByID)]
//        public async Task<IActionResult> GetRoleByID([FromRoute] int id)
//        {

//            return NewResult(await Mediator.Send(new GetRoleByIDQuery(id)));
//        }

//        [HttpPost(Router.RoleRouting.Create)]
//        public async Task<IActionResult> Create([FromBody] AddRoleCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return Ok(response);
//        }
//    }
//}
