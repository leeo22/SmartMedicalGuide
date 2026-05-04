using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.DoctorSchedules.Commands.Models;
using SmartMedicalGuide.Core.Features.DoctorSchedules.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class DoctorScheduleController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all doctor schedules", OperationId = "GetAllDoctorSchedules")]
        [HttpGet(Router.DoctorScheduleRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] int? doctorId, [FromQuery] string? dayOfWeek)
        {
            var response = await Mediator.Send(new GetDoctorScheduleListQuery { DoctorId = doctorId, DayOfWeek = dayOfWeek });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get schedule by ID", OperationId = "GetScheduleById")]
        [HttpGet(Router.DoctorScheduleRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetDoctorScheduleByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new doctor schedule", OperationId = "CreateDoctorSchedule")]
        [HttpPost(Router.DoctorScheduleRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddDoctorScheduleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update doctor schedule", OperationId = "UpdateDoctorSchedule")]
        [HttpPut(Router.DoctorScheduleRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditDoctorScheduleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete doctor schedule", OperationId = "DeleteDoctorSchedule")]
        [HttpDelete(Router.DoctorScheduleRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteDoctorScheduleCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Important Queries
        [SwaggerOperation(Summary = "Get available time slots for doctor", OperationId = "GetAvailableSlots")]
        [HttpGet(Router.DoctorScheduleRouting.GetAvailableSlots)]
        public async Task<IActionResult> GetAvailableSlots([FromQuery] int doctorId, [FromQuery] DateTime date)
        {
            var response = await Mediator.Send(new GetDoctorAvailableSlotsQuery { DoctorId = doctorId, Date = date });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Check doctor availability at specific time", OperationId = "CheckDoctorAvailability")]
        [HttpGet(Router.DoctorScheduleRouting.CheckAvailability)]
        public async Task<IActionResult> CheckAvailability([FromQuery] int doctorId, [FromQuery] DateTime dateTime)
        {
            var response = await Mediator.Send(new CheckDoctorAvailabilityQuery { DoctorId = doctorId, DateTime = dateTime });
            return NewResult(response);
        }
        #endregion
    }
}