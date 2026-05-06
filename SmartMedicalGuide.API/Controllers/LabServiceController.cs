using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.LabServices.Commands.Models;
using SmartMedicalGuide.Core.Features.LabServices.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class LabServiceController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all lab services", OperationId = "GetAllLabServices")]
        [HttpGet(Router.LabServiceRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] int? labId, [FromQuery] string? searchKeyword, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice, [FromQuery] string? category)
        {
            var query = new GetLabServiceListQuery
            {
                LabId = labId,
                SearchKeyword = searchKeyword,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                Category = category
            };
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get lab service by ID", OperationId = "GetLabServiceById")]
        [HttpGet(Router.LabServiceRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetLabServiceByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new lab service", OperationId = "CreateLabService")]
        [HttpPost(Router.LabServiceRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddLabServiceCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update lab service", OperationId = "UpdateLabService")]
        [HttpPut(Router.LabServiceRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditLabServiceCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete lab service", OperationId = "DeleteLabService")]
        [HttpDelete(Router.LabServiceRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteLabServiceCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Important Endpoints
        [SwaggerOperation(Summary = "Get lab services with lab details", OperationId = "GetLabServicesWithLab")]
        [HttpGet(Router.LabServiceRouting.GetWithLab)]
        public async Task<IActionResult> GetWithLab([FromRoute] int labId)
        {
            var response = await Mediator.Send(new GetLabServicesWithLabQuery { LabId = labId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Search lab services", OperationId = "SearchLabServices")]
        [HttpGet(Router.LabServiceRouting.Search)]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var query = new GetLabServiceListQuery { SearchKeyword = keyword };
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        #endregion
    }
}