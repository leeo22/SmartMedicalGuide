using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Prescriptions.Commands.Models;
using SmartMedicalGuide.Core.Features.Prescriptions.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
    
    [ApiController]
    public class PrescriptionController : AppControllerBase
    {
        [HttpGet(Router.PrescriptionRouting.List)]
        public async Task<IActionResult> GetPrescriptionList()
        {
            var response = await Mediator.Send(new GetPrescriptionListQuery());
            return Ok(response);
        }

        [HttpPost(Router.PrescriptionRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddPrescriptionCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.PrescriptionRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditPrescriptionCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.PrescriptionRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeletePrescriptionCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.PrescriptionRouting.GetByID)]
        public async Task<IActionResult> GetPrescriptionByID([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetPrescriptionByIDQuery(id));
            return Ok(response);
        }

    }
}
