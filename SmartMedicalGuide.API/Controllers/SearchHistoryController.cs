//using MediatR;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using SmartMedicalGuide.API.Base;
//using SmartMedicalGuide.Core.Features.SearchHistories.Commands.Models;
//using SmartMedicalGuide.Core.Features.SearchHistoriesQueries.Models;
//using SmartMedicalGuide.Data.AppMetaData;

//namespace SmartMedicalGuide.API.Controllers
//{
    
//    [ApiController]
//    public class SearchHistoryController : AppControllerBase
//    {
//        [HttpGet(Router.SearchHistoryRouting.List)]
//        public async Task<IActionResult> GetSearchHistoryList()
//        {
//            var response = await Mediator.Send(new GetSearchHistoryListQuery());
//            return Ok(response);
//        }

//        [HttpPost(Router.SearchHistoryRouting.Create)]
//        public async Task<IActionResult> Create([FromBody] AddSearchHistoryCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpPut(Router.SearchHistoryRouting.Edit)]
//        public async Task<IActionResult> Edit([FromBody] EditSearchHistoryCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpDelete(Router.SearchHistoryRouting.Delete)]
//        public async Task<IActionResult> Delete([FromBody] DeleteSearchHistoryCommand command)
//        {
//            var response = await Mediator.Send(command);
//            return NewResult(response);
//        }
//        [HttpGet(Router.SearchHistoryRouting.GetByID)]
//        public async Task<IActionResult> GetSearchHistoryByID([FromRoute] int id)
//        {
//            var response = await Mediator.Send(new GetSearchHistoryByIDQuery(id));
//            return Ok(response);
//        }

//    }
//}
