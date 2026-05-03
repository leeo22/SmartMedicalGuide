using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.MedicalReports.Commands.Models;
using SmartMedicalGuide.Core.Features.MedicalReports.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
   
    [ApiController]
    public class MedicalReportController : AppControllerBase
    {
        [HttpGet(Router.MedicalReportRouting.List)]
        public async Task<IActionResult> GetMedicalReportList()
        {
            var response = await Mediator.Send(new GetMedicalReportListQuery());
            return Ok(response);
        }

        [HttpPost(Router.MedicalReportRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddMedicalReportCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.MedicalReportRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditMedicalReportCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.MedicalReportRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteMedicalReportCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.MedicalReportRouting.GetByID)]
        public async Task<IActionResult> GetMedicalReportByID([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetMedicalReportByIDQuery(id));
            return Ok(response);
        }

    }
}
