using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Models;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
  
    [ApiController]
    public class PrescriptionItemController : AppControllerBase
    {
        [HttpGet(Router.PrescriptionItemRouting.List)]
        public async Task<IActionResult> GetPrescriptionItemList()
        {
            var response = await Mediator.Send(new GetPrescriptionItemListQuery());
            return Ok(response);
        }

        [HttpPost(Router.PrescriptionItemRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddPrescriptionItemCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.PrescriptionItemRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditPrescriptionItemCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.PrescriptionItemRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeletePrescriptionItemCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.PrescriptionItemRouting.GetByID)]
        public async Task<IActionResult> GetPrescriptionItemByID([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetPrescriptionItemByIDQuery(id));
            return Ok(response);
        }

    }
}
