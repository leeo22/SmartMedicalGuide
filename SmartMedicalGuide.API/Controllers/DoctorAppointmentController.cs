using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Commands.Models;
using SmartMedicalGuide.Core.Features.DoctorAppointments.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class DoctorAppointmentController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all appointments", OperationId = "GetAllAppointments")]
        [HttpGet(Router.DoctorAppointmentRouting.List)]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetDoctorAppointmentListQuery());
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get appointment by ID", OperationId = "GetAppointmentById")]
        [HttpGet(Router.DoctorAppointmentRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetDoctorAppointmentByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new appointment", OperationId = "CreateAppointment")]
        [HttpPost(Router.DoctorAppointmentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddDoctorAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update appointment", OperationId = "UpdateAppointment")]
        [HttpPut(Router.DoctorAppointmentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditDoctorAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete appointment (soft delete)", OperationId = "DeleteAppointment")]
        [HttpDelete(Router.DoctorAppointmentRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteDoctorAppointmentCommand(id));
            return NewResult(response);
        }
        #endregion
        #region Additional Queries
        [SwaggerOperation(Summary = "Get appointments by Doctor ID", OperationId = "GetAppointmentsByDoctorId")]
        [HttpGet(Router.DoctorAppointmentRouting.GetByDoctorId)]
        public async Task<IActionResult> GetByDoctorId([FromRoute] int doctorId)
        {
            var response = await Mediator.Send(new GetDoctorAppointmentsByDoctorIdQuery { DoctorId = doctorId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get appointments by Patient ID", OperationId = "GetAppointmentsByPatientId")]
        [HttpGet(Router.DoctorAppointmentRouting.GetByPatientId)]
        public async Task<IActionResult> GetByPatientId([FromRoute] int patientId)
        {
            var response = await Mediator.Send(new GetDoctorAppointmentsByPatientIdQuery { PatientId = patientId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get appointments by Date", OperationId = "GetAppointmentsByDate")]
        [HttpGet(Router.DoctorAppointmentRouting.GetByDate)]
        public async Task<IActionResult> GetByDate([FromQuery] DateTime date)
        {
            var response = await Mediator.Send(new GetDoctorAppointmentsByDateQuery { Date = date });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get appointments by Status", OperationId = "GetAppointmentsByStatus")]
        [HttpGet(Router.DoctorAppointmentRouting.GetByStatus)]
        public async Task<IActionResult> GetByStatus([FromRoute] string status)
        {
            var response = await Mediator.Send(new GetDoctorAppointmentsByStatusQuery { Status = status });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get doctor upcoming appointments", OperationId = "GetDoctorUpcomingAppointments")]
        [HttpGet(Router.DoctorAppointmentRouting.GetDoctorUpcoming)]
        public async Task<IActionResult> GetDoctorUpcoming([FromRoute] int doctorId)
        {
            var response = await Mediator.Send(new GetDoctorUpcomingAppointmentsQuery { DoctorId = doctorId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get patient upcoming appointments", OperationId = "GetPatientUpcomingAppointments")]
        [HttpGet(Router.DoctorAppointmentRouting.GetPatientUpcoming)]
        public async Task<IActionResult> GetPatientUpcoming([FromRoute] int patientId)
        {
            var response = await Mediator.Send(new GetPatientUpcomingAppointmentsQuery { PatientId = patientId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get doctor today appointments", OperationId = "GetDoctorTodayAppointments")]
        [HttpGet(Router.DoctorAppointmentRouting.GetDoctorToday)]
        public async Task<IActionResult> GetDoctorToday([FromRoute] int doctorId)
        {
            var response = await Mediator.Send(new GetDoctorTodayAppointmentsQuery { DoctorId = doctorId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get doctor appointments by date range", OperationId = "GetDoctorAppointmentsByDateRange")]
        [HttpGet(Router.DoctorAppointmentRouting.GetByDateRange)]
        public async Task<IActionResult> GetByDateRange([FromQuery] int doctorId, [FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            var response = await Mediator.Send(new GetDoctorAppointmentsByDateRangeQuery
            {
                DoctorId = doctorId,
                FromDate = fromDate,
                ToDate = toDate
            });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get doctor appointments count", OperationId = "GetDoctorAppointmentsCount")]
        [HttpGet(Router.DoctorAppointmentRouting.GetCount)]
        public async Task<IActionResult> GetCount([FromQuery] int doctorId)
        {
            var response = await Mediator.Send(new GetDoctorAppointmentsCountQuery { DoctorId = doctorId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Check doctor availability", OperationId = "CheckDoctorAvailability")]
        [HttpGet(Router.DoctorAppointmentRouting.CheckAvailability)]
        public async Task<IActionResult> CheckAvailability([FromQuery] int doctorId, [FromQuery] DateTime appointmentDate)
        {
            var response = await Mediator.Send(new CheckDoctorAvailabilityQuery { DoctorId = doctorId, AppointmentDate = appointmentDate });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get appointments report", OperationId = "GetAppointmentsReport")]
        [HttpGet(Router.DoctorAppointmentRouting.GetReport)]
        public async Task<IActionResult> GetReport([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var response = await Mediator.Send(new GetAppointmentsReportQuery { FromDate = fromDate, ToDate = toDate });
            return NewResult(response);
        }
        #endregion

        #region Additional Commands
        [SwaggerOperation(Summary = "Cancel appointment", OperationId = "CancelAppointment")]
        [HttpPut(Router.DoctorAppointmentRouting.Cancel)]
        public async Task<IActionResult> Cancel([FromBody] CancelAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Confirm appointment", OperationId = "ConfirmAppointment")]
        [HttpPut(Router.DoctorAppointmentRouting.Confirm)]
        public async Task<IActionResult> Confirm([FromBody] ConfirmAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Complete appointment", OperationId = "CompleteAppointment")]
        [HttpPut(Router.DoctorAppointmentRouting.Complete)]
        public async Task<IActionResult> Complete([FromBody] CompleteAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Reschedule appointment", OperationId = "RescheduleAppointment")]
        [HttpPut(Router.DoctorAppointmentRouting.Reschedule)]
        public async Task<IActionResult> Reschedule([FromBody] RescheduleAppointmentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion
    }
}