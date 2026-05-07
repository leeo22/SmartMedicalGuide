using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Transactions.Queries.Models;
using SmartMedicalGuide.Core.Features.Transactions.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Transactions.Queries.Handlers
{
    public class TransactionQueryHandler : ResponseHandler,
        IRequestHandler<GetTransactionListQuery, Response<List<GetTransactionListResponse>>>,
        IRequestHandler<GetTransactionByIdQuery, Response<GetSingleTransactionResponse>>,
        IRequestHandler<GetWalletBalanceQuery, Response<decimal>>,
        IRequestHandler<GetUserTransactionHistoryQuery, Response<List<GetTransactionListResponse>>>,
        IRequestHandler<GetTransactionStatisticsQuery, Response<object>>
    {
        private readonly ITransactionServices _transactionServices;
        private readonly IMapper _mapper;

        public TransactionQueryHandler(ITransactionServices transactionServices, IMapper mapper)
        {
            _transactionServices = transactionServices;
            _mapper = mapper;
        }

        public async Task<Response<List<GetTransactionListResponse>>> Handle(GetTransactionListQuery request, CancellationToken cancellationToken)
        {
            List<Transaction> transactions;

            if (request.UserId.HasValue)
            {
                transactions = await _transactionServices.GetUserTransactionHistoryAsync(request.UserId.Value);
            }
            else if (request.WalletId.HasValue)
            {
                if (request.Recent.HasValue && request.Recent.Value)
                {
                    var limit = request.Limit ?? 10;
                    transactions = await _transactionServices.GetRecentTransactionsAsync(request.WalletId.Value, limit);
                }
                else
                {
                    transactions = await _transactionServices.GetByWalletIdAsync(request.WalletId.Value);
                }
            }
            else if (!string.IsNullOrWhiteSpace(request.Type))
            {
                transactions = await _transactionServices.GetListAsync();
                transactions = transactions.Where(x => x.Type == request.Type).ToList();
            }
            else if (request.FromDate.HasValue && request.ToDate.HasValue)
            {
                transactions = await _transactionServices.GetListAsync();
                transactions = transactions.Where(x => x.CreatedAt >= request.FromDate.Value && x.CreatedAt <= request.ToDate.Value).ToList();
            }
            else
            {
                transactions = await _transactionServices.GetListAsync();
            }

            var result = _mapper.Map<List<GetTransactionListResponse>>(transactions);
            return Success(result);
        }

        public async Task<Response<GetSingleTransactionResponse>> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionServices.GetByIDAsync(request.Id);
            if (transaction == null)
                return NotFound<GetSingleTransactionResponse>("Transaction not found");

            var result = _mapper.Map<GetSingleTransactionResponse>(transaction);
            return Success(result);
        }

        public async Task<Response<decimal>> Handle(GetWalletBalanceQuery request, CancellationToken cancellationToken)
        {
            var balance = await _transactionServices.GetWalletBalanceAsync(request.WalletId);
            return Success(balance);
        }

        public async Task<Response<List<GetTransactionListResponse>>> Handle(GetUserTransactionHistoryQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionServices.GetUserTransactionHistoryAsync(request.UserId);
            var result = _mapper.Map<List<GetTransactionListResponse>>(transactions);
            return Success(result);
        }

        public async Task<Response<object>> Handle(GetTransactionStatisticsQuery request, CancellationToken cancellationToken)
        {
            var statistics = await _transactionServices.GetTransactionStatisticsAsync();
            return Success(statistics);
        }
    }
}