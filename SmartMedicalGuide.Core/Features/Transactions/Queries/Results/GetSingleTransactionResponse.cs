namespace SmartMedicalGuide.Core.Features.Transactions.Queries.Results
{
    public class GetSingleTransactionResponse
    {
        public int TransactionId { get; set; }
        public int WalletId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ReferenceId { get; set; }
        public string? ReferenceType { get; set; }
        public string? TransactionReference { get; set; }
    }
}