using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Labs.Commands.Models;
using SmartMedicalGuide.Core.Features.Labs.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class LabController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all labs", OperationId = "GetAllLabs")]
        [HttpGet(Router.LabRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] string? location, [FromQuery] string? searchKeyword, [FromQuery] bool? isVerified)
        {
            var query = new GetLabListQuery
            {
                Location = location,
                SearchKeyword = searchKeyword,
                IsVerified = isVerified
            };
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get lab by ID", OperationId = "GetLabById")]
        [HttpGet(Router.LabRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetLabByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new lab", OperationId = "CreateLab")]
        [HttpPost(Router.LabRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddLabCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update lab", OperationId = "UpdateLab")]
        [HttpPut(Router.LabRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditLabCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete lab", OperationId = "DeleteLab")]
        [HttpDelete(Router.LabRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteLabCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Important Endpoints
        [SwaggerOperation(Summary = "Get lab by User ID", OperationId = "GetLabByUserId")]
        [HttpGet(Router.LabRouting.GetByUserId)]
        public async Task<IActionResult> GetByUserId([FromRoute] int userId)
        {
            var response = await Mediator.Send(new GetLabByUserIdQuery(userId));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get lab with services", OperationId = "GetLabWithServices")]
        [HttpGet(Router.LabRouting.GetWithServices)]
        public async Task<IActionResult> GetWithServices([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetLabWithServicesQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Search labs", OperationId = "SearchLabs")]
        [HttpGet(Router.LabRouting.Search)]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var query = new GetLabListQuery { SearchKeyword = keyword };
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get verified labs", OperationId = "GetVerifiedLabs")]
        [HttpGet(Router.LabRouting.GetVerified)]
        public async Task<IActionResult> GetVerified()
        {
            var query = new GetLabListQuery { IsVerified = true };
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update lab verification status", OperationId = "UpdateLabVerificationStatus")]
        [HttpPut(Router.LabRouting.UpdateVerification)]
        public async Task<IActionResult> UpdateVerificationStatus([FromBody] UpdateLabVerificationStatusCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion
    }
}