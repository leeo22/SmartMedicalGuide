//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using SmartMedicalGuide.API.Base;
//using SmartMedicalGuide.Core.Features.Transactions.Commands.Models;
//using SmartMedicalGuide.Core.Features.Transactions.Queries.Models;
//using SmartMedicalGuide.Data.AppMetaData;

//namespace SmartMedicalGuide.API.Controllers
//{

//    [ApiController]
//    public class TransactionController : AppControllerBase
//    {
//        [HttpGet(Router.TransactionRouting.List)]
//        public async Task<IActionResult> GetTransactionList()
//        {
//            var response = await Mediator.Send(new GetTransactionListQuery());
//            return Ok(response);
//        }

//        [HttpPost(Router.TransactionRouting.Create)]
//        public async Task<IActionResult> Create([FromBody] AddTransactionCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpPut(Router.TransactionRouting.Edit)]
//        public async Task<IActionResult> Edit([FromBody] EditTransactionCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpDelete(Router.TransactionRouting.Delete)]
//        public async Task<IActionResult> Delete([FromBody] DeleteTransactionCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpGet(Router.TransactionRouting.GetByID)]
//        public async Task<IActionResult> GetTransactionByID([FromRoute] int id)
//        {
//            var response = await Mediator.Send(new GetTransactionByIDQuery(id));
//            return Ok(response);
//        }



//    }
//}
