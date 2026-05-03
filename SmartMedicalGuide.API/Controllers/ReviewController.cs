using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Reviews.Commands.Models;
using SmartMedicalGuide.Core.Features.Reviews.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
    
    [ApiController]
    public class ReviewController : AppControllerBase
    {
        [HttpGet(Router.ReviewRouting.List)]
        public async Task<IActionResult> GetReviewList()
        {
            var response = await Mediator.Send(new GetReviewListQuery());
            return Ok(response);
        }

        [HttpPost(Router.ReviewRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddReviewCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.ReviewRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditReviewCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.ReviewRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteReviewCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.ReviewRouting.GetByID)]
        public async Task<IActionResult> GetReviewByID([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetReviewByIDQuery(id));
            return Ok(response);
        }

    }
}
