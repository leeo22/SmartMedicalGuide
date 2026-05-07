using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Transactions.Queries.Results;

namespace SmartMedicalGuide.Core.Features.Transactions.Queries.Models
{
    public class GetTransactionListQuery : IRequest<Response<List<GetTransactionListResponse>>>
    {
        public int? WalletId { get; set; }
        public int? UserId { get; set; }
        public string? Type { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? Recent { get; set; }
        public int? Limit { get; set; }
    }
}