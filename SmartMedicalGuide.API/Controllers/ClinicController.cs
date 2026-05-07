using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Clinics.Commands.Models;
using SmartMedicalGuide.Core.Features.Clinics.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    //[Authorize]
    [ApiController]
    public class ClinicController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all clinics", OperationId = "GetAllClinics")]
        [HttpGet(Router.ClinicRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] int? doctorId, [FromQuery] string? location, [FromQuery] string? searchKeyword, [FromQuery] bool? isActive)
        {
            var query = new GetClinicListQuery
            {
                DoctorId = doctorId,
                Location = location,
                SearchKeyword = searchKeyword,
                IsActive = isActive
            };
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get clinic by ID", OperationId = "GetClinicById")]
        [HttpGet(Router.ClinicRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetClinicByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new clinic", OperationId = "CreateClinic")]
        [HttpPost(Router.ClinicRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddClinicCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update clinic", OperationId = "UpdateClinic")]
        [HttpPut(Router.ClinicRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditClinicCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete clinic", OperationId = "DeleteClinic")]
        [HttpDelete(Router.ClinicRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteClinicCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Important Endpoints
        [SwaggerOperation(Summary = "Get clinic with doctor details", OperationId = "GetClinicWithDoctor")]
        [HttpGet(Router.ClinicRouting.GetWithDoctor)]
        public async Task<IActionResult> GetWithDoctor([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetClinicWithDoctorQuery(id));
            return NewResult(response);
        }
        #endregion
    }
}