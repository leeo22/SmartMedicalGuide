using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMedicalGuide.API.Base;
using SmartMedicalGuide.Core.Features.Transactions.Commands.Models;
using SmartMedicalGuide.Core.Features.Transactions.Queries.Models;
using SmartMedicalGuide.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartMedicalGuide.API.Controllers
{
    [Authorize]
    [ApiController]
    public class TransactionController : AppControllerBase
    {
        #region Basic CRUD
        [SwaggerOperation(Summary = "Get all transactions", OperationId = "GetAllTransactions")]
        [HttpGet(Router.TransactionRouting.List)]
        public async Task<IActionResult> GetAll([FromQuery] int? walletId, [FromQuery] int? userId, [FromQuery] string? type, [FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate, [FromQuery] bool? recent, [FromQuery] int? limit)
        {
            var query = new GetTransactionListQuery
            {
                WalletId = walletId,
                UserId = userId,
                Type = type,
                FromDate = fromDate,
                ToDate = toDate,
                Recent = recent,
                Limit = limit
            };
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get transaction by ID", OperationId = "GetTransactionById")]
        [HttpGet(Router.TransactionRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetTransactionByIdQuery(id));
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Create new transaction", OperationId = "CreateTransaction")]
        [HttpPost(Router.TransactionRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddTransactionCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Update transaction", OperationId = "UpdateTransaction")]
        [HttpPut(Router.TransactionRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditTransactionCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Delete transaction", OperationId = "DeleteTransaction")]
        [HttpDelete(Router.TransactionRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteTransactionCommand(id));
            return NewResult(response);
        }
        #endregion

        #region Additional Important Endpoints
        [SwaggerOperation(Summary = "Get wallet balance", OperationId = "GetWalletBalance")]
        [HttpGet(Router.TransactionRouting.GetWalletBalance)]
        public async Task<IActionResult> GetWalletBalance([FromQuery] int walletId)
        {
            var response = await Mediator.Send(new GetWalletBalanceQuery { WalletId = walletId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get user transaction history", OperationId = "GetUserTransactionHistory")]
        [HttpGet(Router.TransactionRouting.GetUserHistory)]
        public async Task<IActionResult> GetUserHistory([FromRoute] int userId)
        {
            var response = await Mediator.Send(new GetUserTransactionHistoryQuery { UserId = userId });
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "Get transaction statistics", OperationId = "GetTransactionStatistics")]
        [HttpGet(Router.TransactionRouting.GetStatistics)]
        public async Task<IActionResult> GetStatistics()
        {
            var response = await Mediator.Send(new GetTransactionStatisticsQuery());
            return NewResult(response);
        }
        #endregion
    }
}