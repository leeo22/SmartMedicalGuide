using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Attachments.Commands.Models;
using SmartMedicalGuide.Core.Features.Attachments.Queries.Models;
using SmartMedicalGuide.Core.Features.Doctors.Commands.Models;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
   
    [ApiController]
    public class AttachmentController : AppControllerBase
    {
        [HttpGet(Router.AttachmentRouting.List)]
        public async Task<IActionResult> GetAttachmentList()
        {
            var response = await Mediator.Send(new GetAttachmentListQuery());
            return Ok(response);
        }

        [HttpPost(Router.AttachmentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddAttachmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.AttachmentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditAttachmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.AttachmentRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteAttachmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.AttachmentRouting.GetByID)]
        public async Task<IActionResult> GetAttachmentByID([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetAttachmentByIDQuery(id));
            return Ok(response);
        }

    }
}
