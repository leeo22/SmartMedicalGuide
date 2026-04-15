using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Favorites.Commands.Models;
using SmartMedicalGuide.Core.Features.Favorites.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;

namespace SmartMedicalGuide.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : AppControllerBase
    {
        #region Fields

        #endregion

        #region Constructors

        #endregion

        #region Handels Functions
        [HttpGet(Router.FavoriteRouting.List)]
        public async Task<IActionResult> GetPaymentList()
        {
            var response = await Mediator.Send(new GetFavoriteListQuery());
            return Ok(response);
        }

        [HttpGet(Router.FavoriteRouting.GetByID)]
        public async Task<IActionResult> GetPaymentByID([FromRoute] int id)
        {

            return NewResult(await Mediator.Send(new GetFavoriteByIDQuery(id)));
        }
        [HttpPost(Router.FavoriteRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddFavoriteCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.FavoriteRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditFavoriteCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.FavoriteRouting.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteFavoriteCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        #endregion
    }
}
