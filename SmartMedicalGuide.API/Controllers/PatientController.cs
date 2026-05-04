using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Patients.Commands.Models;
using SmartMedicalGuide.Core.Features.Patients.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class PatientController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all patients", OperationId = "GetAllPatients")]
        [HttpGet(Router.PatientRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] string? searchKeyword)
        {
            var response = await Mediator.Send(new GetPatientListQuery { SearchKeyword = searchKeyword });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get patient by ID", OperationId = "GetPatientById")]
        [HttpGet(Router.PatientRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetPatientByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new patient", OperationId = "CreatePatient")]
        [HttpPost(Router.PatientRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddPatientCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update patient", OperationId = "UpdatePatient")]
        [HttpPut(Router.PatientRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditPatientCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete patient (soft delete)", OperationId = "DeletePatient")]
        [HttpDelete(Router.PatientRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeletePatientCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Queries
        [SwaggerOperation(Summary = "Get patient by User ID", OperationId = "GetPatientByUserId")]
        [HttpGet(Router.PatientRouting.GetByUserId)]
        public async Task<IActionResult> GetByUserId([FromRoute] int userId)
        {
            var response = await Mediator.Send(new GetPatientByUserIdQuery(userId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get patient appointments", OperationId = "GetPatientAppointments")]
        [HttpGet(Router.PatientRouting.GetAppointments)]
        public async Task<IActionResult> GetAppointments([FromRoute] int patientId)
        {
            var response = await Mediator.Send(new GetPatientAppointmentsQuery(patientId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get patient prescriptions", OperationId = "GetPatientPrescriptions")]
        [HttpGet(Router.PatientRouting.GetPrescriptions)]
        public async Task<IActionResult> GetPrescriptions([FromRoute] int patientId)
        {
            var response = await Mediator.Send(new GetPatientPrescriptionsQuery(patientId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get patient medical reports", OperationId = "GetPatientMedicalReports")]
        [HttpGet(Router.PatientRouting.GetMedicalReports)]
        public async Task<IActionResult> GetMedicalReports([FromRoute] int patientId)
        {
            var response = await Mediator.Send(new GetPatientMedicalReportsQuery(patientId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get patient payment history", OperationId = "GetPatientPaymentHistory")]
        [HttpGet(Router.PatientRouting.GetPaymentHistory)]
        public async Task<IActionResult> GetPaymentHistory([FromRoute] int patientId)
        {
            var response = await Mediator.Send(new GetPatientPaymentHistoryQuery(patientId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get patient upcoming appointments", OperationId = "GetPatientUpcomingAppointments")]
        [HttpGet(Router.PatientRouting.GetUpcomingAppointments)]
        public async Task<IActionResult> GetUpcomingAppointments([FromRoute] int patientId)
        {
            var response = await Mediator.Send(new GetPatientUpcomingAppointmentsQuery(patientId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get patient past appointments", OperationId = "GetPatientPastAppointments")]
        [HttpGet(Router.PatientRouting.GetPastAppointments)]
        public async Task<IActionResult> GetPastAppointments([FromRoute] int patientId)
        {
            var response = await Mediator.Send(new GetPatientPastAppointmentsQuery(patientId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get patient favorite doctors", OperationId = "GetPatientFavoriteDoctors")]
        [HttpGet(Router.PatientRouting.GetFavoriteDoctors)]
        public async Task<IActionResult> GetFavoriteDoctors([FromRoute] int patientId)
        {
            var response = await Mediator.Send(new GetPatientFavoriteDoctorsQuery(patientId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get patient reviews", OperationId = "GetPatientReviews")]
        [HttpGet(Router.PatientRouting.GetReviews)]
        public async Task<IActionResult> GetReviews([FromRoute] int patientId)
        {
            var response = await Mediator.Send(new GetPatientReviewsQuery(patientId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get patient statistics", OperationId = "GetPatientStatistics")]
        [HttpGet(Router.PatientRouting.GetStatistics)]
        public async Task<IActionResult> GetStatistics([FromRoute] int patientId)
        {
            var response = await Mediator.Send(new GetPatientStatisticsQuery(patientId));
            return NewResult(response);
        }
        #endregion

        #region Additional Commands
        [SwaggerOperation(Summary = "Update patient profile", OperationId = "UpdatePatientProfile")]
        [HttpPut(Router.PatientRouting.UpdateProfile)]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdatePatientProfileCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion
    }
}