namespace SmartMedicalGuide.Core.Features.Wallets.Queries.Results
{
    public class GetWalletListResponse
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal TotalBalance { get; set; }
        public string Currency { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}