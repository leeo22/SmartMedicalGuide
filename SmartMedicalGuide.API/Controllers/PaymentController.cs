using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Payments.Commands.Models;
using SmartMedicalGuide.Core.Features.Payments.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{

    [ApiController]
    public class PaymentController : AppControllerBase
    {
        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Handels Functions
        [HttpGet(Router.PaymentRouting.List)]
        public async Task<IActionResult> GetPaymentList()
        {
            var response = await Mediator.Send(new GetPaymentListQuery());
            return Ok(response);
        }

        [HttpGet(Router.PaymentRouting.GetByID)]
        public async Task<IActionResult> GetPaymentByID([FromRoute] int id)
        {

            return NewResult(await Mediator.Send(new GetPaymentByIDQuery(id)));
        }
        [HttpPost(Router.PaymentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddPaymentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.PaymentRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditPaymentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.PaymentRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeletePaymentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion
    }
}
