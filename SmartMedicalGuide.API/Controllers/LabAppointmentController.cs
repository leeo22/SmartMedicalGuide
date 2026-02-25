using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Clinics.Commands.Models;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models;
using SmartMedicalGuide.Core.Features.Doctors.Queries.Models;
using SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models;
using SmartMedicalGuide.Core.Features.LabAppointments.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
    
    [ApiController]
    public class LabAppointmentController : AppControllerBase
    {
        [HttpGet(Router.LabAppointmentRouting.List)]
        public async Task<IActionResult> GetLabAppointmentList()
        {
            var response = await Mediator.Send(new GetLabAppointmentListQuery());
            return Ok(response);
        }
        [HttpPost(Router.LabAppointmentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddLabAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.LabAppointmentRouting.GetByID)]
        public async Task<IActionResult> GetLabAppointmentByID([FromRoute] int id)
        {

            return NewResult(await Mediator.Send(new GetLabAppointmentByIDQuery(id)));
        }

        [HttpPut(Router.LabAppointmentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditLabAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.LabAppointmentRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteLabAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

    }
}
