using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Prescriptions.Commands.Models;
using SmartMedicalGuide.Core.Features.Prescriptions.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class PrescriptionController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all prescriptions", OperationId = "GetAllPrescriptions")]
        [HttpGet(Router.PrescriptionRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] int? patientId, [FromQuery] int? doctorId, [FromQuery] int? appointmentId, [FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate, [FromQuery] string? status)
        {
            var query = new GetPrescriptionListQuery
            {
                PatientId = patientId,
                DoctorId = doctorId,
                AppointmentId = appointmentId,
                FromDate = fromDate,
                ToDate = toDate,
                Status = status
            };
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get prescription by ID", OperationId = "GetPrescriptionById")]
        [HttpGet(Router.PrescriptionRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetPrescriptionByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new prescription", OperationId = "CreatePrescription")]
        [HttpPost(Router.PrescriptionRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddPrescriptionCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update prescription", OperationId = "UpdatePrescription")]
        [HttpPut(Router.PrescriptionRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditPrescriptionCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete prescription", OperationId = "DeletePrescription")]
        [HttpDelete(Router.PrescriptionRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeletePrescriptionCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Important Endpoints
        [SwaggerOperation(Summary = "Get prescription with items", OperationId = "GetPrescriptionWithItems")]
        [HttpGet(Router.PrescriptionRouting.GetWithItems)]
        public async Task<IActionResult> GetWithItems([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetPrescriptionWithItemsQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update prescription status", OperationId = "UpdatePrescriptionStatus")]
        [HttpPut(Router.PrescriptionRouting.UpdateStatus)]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdatePrescriptionStatusCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get prescription statistics", OperationId = "GetPrescriptionStatistics")]
        [HttpGet(Router.PrescriptionRouting.GetStatistics)]
        public async Task<IActionResult> GetStatistics()
        {
            var response = await Mediator.Send(new GetPrescriptionStatisticsQuery());
            return NewResult(response);
        }
        #endregion
    }
}