using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.LabsServices.Commands.Models;
using SmartMedicalGuide.Core.Features.LabsServices.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{

    [ApiController]
    public class LabServiceController : AppControllerBase
    {
        [HttpGet(Router.LabServiceRouting.List)]
        public async Task<IActionResult> GetLabServiceList()
        {
            var response = await Mediator.Send(new GetLabServiceListQuery());
            return Ok(response);
        }

        [HttpPost(Router.LabServiceRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddLabServiceCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.LabServiceRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditLabServiceCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.LabServiceRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteLabServiceCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.LabServiceRouting.GetByID)]
        public async Task<IActionResult> GetLabServiceByID([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetLabServiceByIDQuery(id));
            return Ok(response);
        }

    }
}
