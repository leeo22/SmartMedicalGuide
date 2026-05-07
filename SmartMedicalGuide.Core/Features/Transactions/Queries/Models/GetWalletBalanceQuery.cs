using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Transactions.Queries.Models
{
    public class GetWalletBalanceQuery : IRequest<Response<decimal>>
    {
        public int WalletId { get; set; }
    }
}