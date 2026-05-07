using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Transactions.Commands.Models
{
    public class AddTransactionCommand : IRequest<Response<string>>
    {
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public int? ReferenceId { get; set; }
        public string? ReferenceType { get; set; }
        public string? TransactionReference { get; set; }
    }
}