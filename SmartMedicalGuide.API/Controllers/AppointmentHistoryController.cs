using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.AppointmentHistories.Commands.Models;
using SmartMedicalGuide.Core.Features.AppointmentHistories.Queries.Models;
using SmartMedicalGuide.Core.Features.Doctors.Commands.Models;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{

    [ApiController]
    public class AppointmentHistoryController : AppControllerBase
    {
        [HttpGet(Router.AppointmentHistoryRouting.List)]
        public async Task<IActionResult> GetAppointmentHistoryList()
        {
            var response = await Mediator.Send(new GetAppointmentHistoryListQuery());
            return Ok(response);
        }

        [HttpPost(Router.AppointmentHistoryRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddAppointmentHistoryCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.AppointmentHistoryRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditAppointmentHistoryCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.AppointmentHistoryRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteAppointmentHistoryCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.AppointmentHistoryRouting.GetByID)]
        public async Task<IActionResult> GetAppointmentHistoryByID([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetAppointmentHistoryByIDQuery(id));
            return Ok(response);
        }

    }
}
