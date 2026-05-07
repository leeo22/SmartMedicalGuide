using MediatR;
using SmartMedicalGuide.Core.Bases;

namespace SmartMedicalGuide.Core.Features.Transactions.Commands.Models
{
    public class EditTransactionCommand : IRequest<Response<string>>
    {
        public int TransactionId { get; set; }
        public decimal? Amount { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int? ReferenceId { get; set; }
        public string? ReferenceType { get; set; }
        public string? TransactionReference { get; set; }
    }
}