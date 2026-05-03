//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using SmartMedicalGuide.API.Base;
//using SmartMedicalGuide.Core.Features.Wallets.Commands.Models;
//using SmartMedicalGuide.Core.Features.Wallets.Queries.Models;
//using SmartMedicalGuide.Data.AppMetaData;

//namespace SmartMedicalGuide.API.Controllers
//{
    
//    [ApiController]
//    public class WalletController : AppControllerBase
//    {
//        [HttpGet(Router.WalletRouting.List)]
//        public async Task<IActionResult> GetWalletList()
//        {
//            var response = await Mediator.Send(new GetWalletListQuery());
//            return Ok(response);
//        }

//        [HttpPost(Router.WalletRouting.Create)]
//        public async Task<IActionResult> Create([FromBody] AddWalletCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpPut(Router.WalletRouting.Edit)]
//        public async Task<IActionResult> Edit([FromBody] EditWalletCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpDelete(Router.WalletRouting.Delete)]
//        public async Task<IActionResult> Delete([FromBody] DeleteWalletCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpGet(Router.WalletRouting.GetByID)]
//        public async Task<IActionResult> GetWalletByID([FromRoute] int id)
//        {
//            var response = await Mediator.Send(new GetWalletByIDQuery(id));
//            return Ok(response);
//        }

//    }
//}
