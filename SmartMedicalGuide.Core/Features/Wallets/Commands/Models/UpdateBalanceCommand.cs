using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Wallets.Commands.Models
{
    public class UpdateBalanceCommand : IRequest<Response<bool>>
    {
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public bool IsAddition { get; set; }
    }
}