using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Clinics.Commands.Models;
using SmartMedicalGuide.Core.Features.Clinics.Queries.Models;
using SmartMedicalGuide.Core.Features.Labs.Commands.Models;
using SmartMedicalGuide.Core.Features.Labs.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
    
    [ApiController]
    public class ClinicController : AppControllerBase
    {
        [HttpGet(Router.ClinicRouting.List)]
        public async Task<IActionResult> GetClinicList()
        {
            var response = await Mediator.Send(new GetClinicListQuery());
            return Ok(response);
        }

        [HttpPost(Router.ClinicRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddClinicCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.ClinicRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditClinicCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.ClinicRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteClinicCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.ClinicRouting.GetByID)]
        public async Task<IActionResult> GetClinicByID([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetClinicByIDQuery(id));
            return Ok(response);
        }
    }
}
