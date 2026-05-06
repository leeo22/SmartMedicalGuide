using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Commands.Models;
using SmartMedicalGuide.Core.Features.PrescriptionItems.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class PrescriptionItemController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all prescription items", OperationId = "GetAllPrescriptionItems")]
        [HttpGet(Router.PrescriptionItemRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] int? prescriptionId, [FromQuery] string? medicineName)
        {
            var query = new GetPrescriptionItemListQuery
            {
                PrescriptionId = prescriptionId,
                MedicineName = medicineName
            };
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get prescription item by ID", OperationId = "GetPrescriptionItemById")]
        [HttpGet(Router.PrescriptionItemRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetPrescriptionItemByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new prescription item", OperationId = "CreatePrescriptionItem")]
        [HttpPost(Router.PrescriptionItemRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddPrescriptionItemCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update prescription item", OperationId = "UpdatePrescriptionItem")]
        [HttpPut(Router.PrescriptionItemRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditPrescriptionItemCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete prescription item", OperationId = "DeletePrescriptionItem")]
        [HttpDelete(Router.PrescriptionItemRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeletePrescriptionItemCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Important Endpoints
        [SwaggerOperation(Summary = "Get prescription items with details", OperationId = "GetPrescriptionItemsWithDetails")]
        [HttpGet(Router.PrescriptionItemRouting.GetWithDetails)]
        public async Task<IActionResult> GetWithDetails([FromQuery] int prescriptionId)
        {
            var response = await Mediator.Send(new GetPrescriptionItemsWithDetailsQuery { PrescriptionId = prescriptionId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Bulk add prescription items", OperationId = "BulkAddPrescriptionItems")]
        [HttpPost(Router.PrescriptionItemRouting.BulkAdd)]
        public async Task<IActionResult> BulkAdd([FromBody] BulkAddPrescriptionItemsCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update item quantity", OperationId = "UpdateItemQuantity")]
        [HttpPut(Router.PrescriptionItemRouting.UpdateQuantity)]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateItemQuantityCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion
    }
}