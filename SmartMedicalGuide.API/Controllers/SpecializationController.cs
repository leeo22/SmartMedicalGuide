using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Specializations.Commands.Models;
using SmartMedicalGuide.Core.Features.Specializations.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
    [ApiController]
    public class SpecializationController : AppControllerBase
    {
        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Handels Functions
        [HttpGet(Router.SpecializationRouting.List)]
        public async Task<IActionResult> GetPaymentList()
        {
            var response = await Mediator.Send(new GetSpecializationListQuery());
            return Ok(response);
        }

        [HttpGet(Router.SpecializationRouting.GetByID)]
        public async Task<IActionResult> GetPaymentByID([FromRoute] int id)
        {

            return NewResult(await Mediator.Send(new GetSpecializationByIDQuery(id)));
        }
        [HttpPost(Router.SpecializationRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddSpecializationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.SpecializationRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditSpecializationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.SpecializationRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteSpecializationCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion
    }
}
