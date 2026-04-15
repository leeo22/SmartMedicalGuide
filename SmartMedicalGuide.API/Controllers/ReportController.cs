using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Reports.Commands.Models;
using SmartMedicalGuide.Core.Features.Reports.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
    [ApiController]
    public class ReportController : AppControllerBase
    {
        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Handels Functions
        [HttpGet(Router.ReportRouting.List)]
        public async Task<IActionResult> GetPaymentList()
        {
            var response = await Mediator.Send(new GetReportListQuery());
            return Ok(response);
        }

        [HttpGet(Router.ReportRouting.GetByID)]
        public async Task<IActionResult> GetPaymentByID([FromRoute] int id)
        {

            return NewResult(await Mediator.Send(new GetReportByIDQuery(id)));
        }
        [HttpPost(Router.ReportRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddReportCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.ReportRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditReportCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.ReportRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteReportCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion
    }
}
