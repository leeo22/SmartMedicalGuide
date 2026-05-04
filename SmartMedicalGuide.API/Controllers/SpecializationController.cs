using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Specializations.Commands.Models;
using SmartMedicalGuide.Core.Features.Specializations.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class SpecializationController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all specializations", OperationId = "GetAllSpecializations")]
        [HttpGet(Router.SpecializationRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] string? searchKeyword, [FromQuery] bool? includeDoctorCount = false)
        {
            var query = new GetSpecializationListQuery
            {
                SearchKeyword = searchKeyword,
                IncludeDoctorCount = includeDoctorCount
            };
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get specialization by ID", OperationId = "GetSpecializationById")]
        [HttpGet(Router.SpecializationRouting.GetByID)]
        [AllowAnonymous]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetSpecializationByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new specialization", OperationId = "CreateSpecialization")]
        [HttpPost(Router.SpecializationRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddSpecializationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update specialization", OperationId = "UpdateSpecialization")]
        [HttpPut(Router.SpecializationRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditSpecializationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete specialization (soft delete)", OperationId = "DeleteSpecialization")]
        [HttpDelete(Router.SpecializationRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteSpecializationCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Queries
        [SwaggerOperation(Summary = "Get specialization by name", OperationId = "GetSpecializationByName")]
        [HttpGet(Router.SpecializationRouting.GetByName)]
        [AllowAnonymous]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            var response = await Mediator.Send(new GetSpecializationByNameQuery { Name = name });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Search specializations", OperationId = "SearchSpecializations")]
        [HttpGet(Router.SpecializationRouting.Search)]
        [AllowAnonymous]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var response = await Mediator.Send(new SearchSpecializationsQuery { Keyword = keyword });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get popular specializations", OperationId = "GetPopularSpecializations")]
        [HttpGet(Router.SpecializationRouting.GetPopular)]
        [AllowAnonymous]
        public async Task<IActionResult> GetPopular([FromQuery] int limit = 10)
        {
            var response = await Mediator.Send(new GetPopularSpecializationsQuery { Limit = limit });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get specialization with details (doctors)", OperationId = "GetSpecializationWithDetails")]
        [HttpGet(Router.SpecializationRouting.GetWithDetails)]
        [AllowAnonymous]
        public async Task<IActionResult> GetWithDetails([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetSpecializationWithDetailsQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get specialization statistics", OperationId = "GetSpecializationStatistics")]
        [HttpGet(Router.SpecializationRouting.GetStatistics)]
        public async Task<IActionResult> GetStatistics([FromRoute] int specializationId)
        {
            var response = await Mediator.Send(new GetSpecializationStatisticsQuery(specializationId));
            return NewResult(response);
        }
        #endregion
    }
}