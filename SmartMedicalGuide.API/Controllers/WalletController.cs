using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Wallets.Commands.Models;
using SmartMedicalGuide.Core.Features.Wallets.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class WalletController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all wallets", OperationId = "GetAllWallets")]
        [HttpGet(Router.WalletRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] bool? onlyDoctors, [FromQuery] bool? onlyActive)
        {
            var response = await Mediator.Send(new GetWalletListQuery { OnlyDoctors = onlyDoctors, OnlyActive = onlyActive });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get wallet by ID", OperationId = "GetWalletById")]
        [HttpGet(Router.WalletRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetWalletByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get wallet by User ID", OperationId = "GetWalletByUserId")]
        [HttpGet(Router.WalletRouting.GetByUserId)]
        public async Task<IActionResult> GetByUserId([FromQuery] int userId)
        {
            var response = await Mediator.Send(new GetWalletByUserIdQuery { UserId = userId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new wallet", OperationId = "CreateWallet")]
        [HttpPost(Router.WalletRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddWalletCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update wallet", OperationId = "UpdateWallet")]
        [HttpPut(Router.WalletRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditWalletCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete wallet", OperationId = "DeleteWallet")]
        [HttpDelete(Router.WalletRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteWalletCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Important Endpoints
        [SwaggerOperation(Summary = "Update wallet balance", OperationId = "UpdateBalance")]
        [HttpPut(Router.WalletRouting.UpdateBalance)]
        public async Task<IActionResult> UpdateBalance([FromBody] UpdateBalanceCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Transfer between wallets", OperationId = "TransferBetweenWallets")]
        [HttpPost(Router.WalletRouting.Transfer)]
        public async Task<IActionResult> Transfer([FromBody] TransferBetweenWalletsCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get wallet statistics", OperationId = "GetWalletStatistics")]
        [HttpGet(Router.WalletRouting.GetStatistics)]
        public async Task<IActionResult> GetStatistics()
        {
            var response = await Mediator.Send(new GetWalletStatisticsQuery());
            return NewResult(response);
        }
        #endregion
    }
}