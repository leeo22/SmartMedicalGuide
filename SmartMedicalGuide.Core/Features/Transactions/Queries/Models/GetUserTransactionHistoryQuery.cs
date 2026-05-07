using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Transactions.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Transactions.Queries.Models
{
    public class GetUserTransactionHistoryQuery : IRequest<Response<List<GetTransactionListResponse>>>
    {
        public int UserId { get; set; }
    }
}