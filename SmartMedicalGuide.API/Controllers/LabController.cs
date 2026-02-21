using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Labs.Commands.Models;
using SmartMedicalGuide.Core.Features.Labs.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
    [ApiController]
    public class LabController : AppControllerBase
    {
        [HttpGet(Router.LabRouting.List)]
        public async Task<IActionResult> GetLabList()
        {
            var response = await Mediator.Send(new GetLabListQuery());
            return Ok(response);
        }

        [HttpPost(Router.LabRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddLabCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.LabRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditLabCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.LabRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteLabCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.LabRouting.GetByID)]
        public async Task<IActionResult> GetLabByID([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetLabByIDQuery(id));
            return Ok(response);
        }
    }
}
