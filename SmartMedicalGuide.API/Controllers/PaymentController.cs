using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Payments.Commands.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{

    [ApiController]
    public class PaymentController : AppControllerBase
    {
        [HttpPost(Router.PaymentRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddPaymentCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
