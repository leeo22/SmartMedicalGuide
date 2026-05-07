using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Commands.Models;
using SmartMedicalGuide.Core.Features.DoctorCapacitySettings.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using SmartMedicalGuide.Data.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    //[Authorize]
    [ApiController]
    public class DoctorCapacitySettingController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all capacity settings", OperationId = "GetAllCapacitySettings")]
        [HttpGet(Router.DoctorCapacitySettingRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] int? doctorId, [FromQuery] bool? isActive, [FromQuery] int? minCapacity, [FromQuery] ShiftType? shiftType, [FromQuery] BookingType? bookingType)
        {
            var query = new GetDoctorCapacitySettingListQuery
            {
                DoctorId = doctorId,
                IsActive = isActive,
                MinCapacity = minCapacity,
                ShiftType = shiftType,
                BookingType = bookingType
            };
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get capacity setting by ID", OperationId = "GetCapacitySettingById")]
        [HttpGet(Router.DoctorCapacitySettingRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetDoctorCapacitySettingByIDQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new capacity setting", OperationId = "CreateCapacitySetting")]
        [HttpPost(Router.DoctorCapacitySettingRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddDoctorCapacitySettingCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update capacity setting", OperationId = "UpdateCapacitySetting")]
        [HttpPut(Router.DoctorCapacitySettingRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditDoctorCapacitySettingCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete capacity setting", OperationId = "DeleteCapacitySetting")]
        [HttpDelete(Router.DoctorCapacitySettingRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteDoctorCapacitySettingCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Business Functions
        [SwaggerOperation(Summary = "Get capacity setting by Doctor ID", OperationId = "GetCapacitySettingByDoctorId")]
        [HttpGet(Router.DoctorCapacitySettingRouting.GetByDoctorId)]
        public async Task<IActionResult> GetByDoctorId([FromRoute] int doctorId)
        {
            var query = new GetDoctorCapacitySettingListQuery { DoctorId = doctorId };
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get remaining capacity for a doctor on a specific date", OperationId = "GetRemainingCapacity")]
        [HttpGet(Router.DoctorCapacitySettingRouting.GetRemainingCapacity)]
        public async Task<IActionResult> GetRemainingCapacity([FromQuery] int doctorId, [FromQuery] DateTime appointmentDate)
        {
            var response = await Mediator.Send(new GetRemainingCapacityQuery { DoctorId = doctorId, AppointmentDate = appointmentDate });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Check if doctor is available on a specific date", OperationId = "CheckAvailability")]
        [HttpGet(Router.DoctorCapacitySettingRouting.CheckAvailability)]
        public async Task<IActionResult> CheckAvailability([FromQuery] int doctorId, [FromQuery] DateTime appointmentDate)
        {
            var response = await Mediator.Send(new CheckAvailabilityQuery { DoctorId = doctorId, AppointmentDate = appointmentDate });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Decrement daily capacity after booking", OperationId = "DecrementCapacity")]
        [HttpPut(Router.DoctorCapacitySettingRouting.DecrementCapacity)]
        public async Task<IActionResult> DecrementCapacity([FromBody] DecrementDailyCapacityCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get capacity report for date range", OperationId = "GetCapacityReport")]
        [HttpGet(Router.DoctorCapacitySettingRouting.GetCapacityReport)]
        public async Task<IActionResult> GetCapacityReport([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var response = await Mediator.Send(new GetCapacityReportQuery { FromDate = fromDate, ToDate = toDate });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Bulk update capacity settings", OperationId = "BulkUpdateCapacitySettings")]
        [HttpPut(Router.DoctorCapacitySettingRouting.BulkUpdate)]
        public async Task<IActionResult> BulkUpdate([FromBody] BulkUpdateCapacitySettingsCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion
    }
}