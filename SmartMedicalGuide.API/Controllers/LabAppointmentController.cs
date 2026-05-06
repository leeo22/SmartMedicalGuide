using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.LabAppointments.Commands.Models;
using SmartMedicalGuide.Core.Features.LabAppointments.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class LabAppointmentController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all lab appointments", OperationId = "GetAllLabAppointments")]
        [HttpGet(Router.LabAppointmentRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] int? labId, [FromQuery] int? patientId, [FromQuery] string? status, [FromQuery] DateTime? date, [FromQuery] bool? upcoming)
        {
            var query = new GetLabAppointmentListQuery
            {
                LabId = labId,
                PatientId = patientId,
                Status = status,
                Date = date,
                Upcoming = upcoming
            };
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get lab appointment by ID", OperationId = "GetLabAppointmentById")]
        [HttpGet(Router.LabAppointmentRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetLabAppointmentByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new lab appointment", OperationId = "CreateLabAppointment")]
        [HttpPost(Router.LabAppointmentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddLabAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update lab appointment", OperationId = "UpdateLabAppointment")]
        [HttpPut(Router.LabAppointmentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditLabAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete lab appointment", OperationId = "DeleteLabAppointment")]
        [HttpDelete(Router.LabAppointmentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteLabAppointmentCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Important Endpoints
        [SwaggerOperation(Summary = "Cancel lab appointment", OperationId = "CancelLabAppointment")]
        [HttpPut(Router.LabAppointmentRouting.Cancel)]
        public async Task<IActionResult> Cancel([FromBody] CancelLabAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Confirm lab appointment", OperationId = "ConfirmLabAppointment")]
        [HttpPut(Router.LabAppointmentRouting.Confirm)]
        public async Task<IActionResult> Confirm([FromBody] ConfirmLabAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Complete lab appointment", OperationId = "CompleteLabAppointment")]
        [HttpPut(Router.LabAppointmentRouting.Complete)]
        public async Task<IActionResult> Complete([FromBody] CompleteLabAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Check lab availability", OperationId = "CheckLabAvailability")]
        [HttpGet(Router.LabAppointmentRouting.CheckAvailability)]
        public async Task<IActionResult> CheckAvailability([FromQuery] int labId, [FromQuery] DateTime appointmentDate)
        {
            var response = await Mediator.Send(new CheckLabAvailabilityQuery { LabId = labId, AppointmentDate = appointmentDate });
            return NewResult(response);
        }
        #endregion
    }
}