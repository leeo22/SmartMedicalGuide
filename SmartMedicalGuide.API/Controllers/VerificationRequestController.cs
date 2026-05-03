//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using SmartMedicalGuide.API.Base;
//using SmartMedicalGuide.Core.Features.VerificationRequests.Commands.Models;
//using SmartMedicalGuide.Core.Features.VerificationRequests.Queries.Models;
//using SmartMedicalGuide.Data.AppMetaData;

//namespace SmartMedicalGuide.API.Controllers
//{
    
//    [ApiController]
//    public class VerificationRequestController : AppControllerBase
//    {
//        [HttpGet(Router.VerificationRequestRouting.List)]
//        public async Task<IActionResult> GetVerificationRequestList()
//        {
//            var response = await Mediator.Send(new GetVerificationRequestListQuery());
//            return Ok(response);
//        }

//        [HttpPost(Router.VerificationRequestRouting.Create)]
//        public async Task<IActionResult> Create([FromBody] AddVerificationRequestCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpPut(Router.VerificationRequestRouting.Edit)]
//        public async Task<IActionResult> Edit([FromBody] EditVerificationRequestCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpDelete(Router.VerificationRequestRouting.Delete)]
//        public async Task<IActionResult> Delete([FromBody] DeleteVerificationRequestCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpGet(Router.VerificationRequestRouting.GetByID)]
//        public async Task<IActionResult> GetVerificationRequestByID([FromRoute] int id)
//        {
//            var response = await Mediator.Send(new GetVerificationRequestByIDQuery(id));
//            return Ok(response);
//        }

//    }
//}
